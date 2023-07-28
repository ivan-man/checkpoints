using System.Reflection;
using Hid.Checkpoint.Audit;
using Hid.Checkpoint.Business.HttpClients;
using Hid.Checkpoint.Business.Options;
using Hid.Checkpoint.Caching;
using Hid.Checkpoint.DataAccess.Ef;
using Hid.Checkpoint.MediatR;
using Hid.Identity.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hid.Checkpoint.Business;

public static class DependencyInjection
{
    private const string EmailOptionsSection = "EmailOptions";

    public static IServiceCollection AddBusiness(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddHidCaching(configuration)
            .AddMediatoRs(Assembly.GetExecutingAssembly())
            .AddDataAccess(configuration)
            .AddAudit(configuration)
            .AddOptions()
            .Configure<EmailOptions>(options => { configuration.GetSection(EmailOptionsSection).Bind(options); })
            .AddImbeddedIdentityClient(configuration, sectionName: "JwtOptions")
            .AddCurrentUserService()
            .AddHidAuthorization()
            .AddDpmsApiClient(configuration);

        return services;
    }
}
