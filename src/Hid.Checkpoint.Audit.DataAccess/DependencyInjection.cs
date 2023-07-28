using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hid.Checkpoint.Audit.DataAccess;

public static class DependencyInjection
{
    private const string ConnectionStringName = "Audit";

    public static IServiceCollection AddAuditDataAccess(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringName = ConnectionStringName)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddDbContext<AuditContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(connectionStringName));
            options.UseSnakeCaseNamingConvention();
        });

        return services;
    }
}
