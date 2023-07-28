using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;

namespace Hid.Shared.Ef.Interceptors;

public class QueryDateTimeInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        RemoveKindsFromCommand(command);

        return result;
    }

    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        RemoveKindsFromCommand(command);

        return new ValueTask<InterceptionResult<DbDataReader>>(result);
    }

    private static void RemoveKindsFromCommand(DbCommand command)
    {
        foreach (var parameter in command.Parameters)
        {
            var npSqlParameter = parameter as NpgsqlParameter;
            if (npSqlParameter is not { DbType: DbType.DateTime2 }) 
                continue;
            
            var date = npSqlParameter.Value as DateTime?;
            if (date == null) 
                continue;
            
            if (date.Value.Kind == DateTimeKind.Unspecified)
                continue;
                    
            date = date.Value.ToUniversalTime();
            date = DateTime.SpecifyKind(date.Value, DateTimeKind.Unspecified);
                    
            npSqlParameter.Value = date;
        }
    }
}
