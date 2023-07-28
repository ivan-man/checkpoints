using Hid.Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hid.Identity.DataAccess.Ef;

public static class DependencyInjection
{
    private const string ConnectionStringName = "Identity";
    
    public static IServiceCollection AddIdentityDataAccess(
        this IServiceCollection services, 
        IConfiguration configuration,
        string connectionStringName = ConnectionStringName)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        services
            .AddDbContext<HidIdentityContext>((sp, options) =>
                options.UseNpgsql(configuration.GetConnectionString(connectionStringName)));
        
        services.AddIdentity<ApplicationUser, ApplicationUserRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                // options.SignIn.RequireConfirmedPhoneNumber = true;
            })
            .AddEntityFrameworkStores<HidIdentityContext>()
            .AddDefaultTokenProviders();
        
        // services.AddDbContext<HidIdentityContext>();
        
        return services;
    }
}
