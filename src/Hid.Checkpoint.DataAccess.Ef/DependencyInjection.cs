using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hid.Checkpoint.DataAccess.Ef;

public static class DependencyInjection
{
    private const string ConnectionStringName = "CheckPoints";
    
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services, 
        IConfiguration configuration,
        string connectionStringName = ConnectionStringName)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddDbContext<CheckPointsContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(connectionStringName));
            options.UseSnakeCaseNamingConvention();
        });
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
