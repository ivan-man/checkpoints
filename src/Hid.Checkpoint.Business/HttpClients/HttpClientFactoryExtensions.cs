using Hid.Checkpoint.Business.HttpClients.Dpms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace Hid.Checkpoint.Business.HttpClients;

public static class HttpClientFactoryExtensions
{
    private const string DpmsApiOptionsPath = "externalApi:dpmsGazprom:address";
    private const string DpmsApiClientName = "dpmsApi";
    
    public static IServiceCollection AddDpmsApiClient(
        this IServiceCollection services,
        IConfiguration configuration,
        string path = DpmsApiOptionsPath)
    {
        var dpmsApiAddress = configuration.GetValue<string>(path);
        if (string.IsNullOrWhiteSpace(dpmsApiAddress))
            throw new InvalidOperationException("Failed to get dpms api address from config");

        services.AddHttpClient(DpmsApiClientName,
                httpClient => { httpClient.BaseAddress = new Uri(dpmsApiAddress); })
            .SetHandlerLifetime(new TimeSpan(0, 0, 0, 0, Timeout.Infinite))
            .AddPolicyHandler(HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

        services.AddScoped<IDpmsApiClient, DpmsApiClient>();
        
        return services;
    }

    public static HttpClient CreateDpmsApiClient(this IHttpClientFactory factory)
    {
        return factory.CreateClient(DpmsApiClientName);
    }
}
