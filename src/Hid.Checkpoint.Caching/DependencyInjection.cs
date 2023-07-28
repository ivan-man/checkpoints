using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hid.Checkpoint.Caching;

public static class DependencyInjection
{
    public static IServiceCollection AddHidCaching(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDistributedMemoryCache();
        return services;
    }
}
