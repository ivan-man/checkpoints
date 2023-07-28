using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Hid.Checkpoint.MediatR;

public static class DependencyInjection
{
    public static IServiceCollection AddMediatoRs(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly ?? throw new ArgumentNullException(nameof(assembly)));
                cfg.AddOpenBehavior(typeof(FluentValidationBehaviour<,>));
                
                //ToDo add behaviors if need
            })
            .AddValidatorsFromAssembly(assembly);

        return services;
    }
}
