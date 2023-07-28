using Hid.Checkpoint.MediatR;
using Hid.Identity.Business.InternalServices.Tokens;
using Hid.Identity.Common;
using Hid.Identity.DataAccess.Ef;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hid.Identity.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityBusiness(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddOptions<JwtOptions>("jwtOptions");
            
        services
            .AddIdentityDataAccess(configuration)
            .AddMediatoRs(typeof(DependencyInjection).Assembly)
            .AddTransient<IJwtTokenManager, JwtTokenManager>();
    
        return services;
    }
}
