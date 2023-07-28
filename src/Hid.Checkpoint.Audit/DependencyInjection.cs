using System.Reflection;
using Hid.Checkpoint.Audit.Abstractions.Interfaces;
using Hid.Checkpoint.Audit.DataAccess;
using Hid.Checkpoint.Audit.Interceptors;
using Hid.Checkpoint.Audit.Services;
using Hid.Checkpoint.MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hid.Checkpoint.Audit;

public static class DependencyInjection
{
    private const string ConnectionStringName = "Audit";
    
    public static IServiceCollection AddAudit(
        this IServiceCollection services, 
        IConfiguration configuration, 
        string connectionStringName = ConnectionStringName)
    {
        services
            .AddMediatoRs(Assembly.GetExecutingAssembly())
            .AddAuditDataAccess(configuration, connectionStringName)
            .AddSingleton<IStorageService, StorageService>()
            .AddSingleton<IEntitiesInfoStore, EntitiesInfoStore>()
            .AddSingleton<IChangesDetector, EntityEntryChangesDetector>()
            .AddScoped<AuditSavingInterceptor>();
        
        return services;
    }
}
