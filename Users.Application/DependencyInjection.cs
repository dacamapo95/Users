using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Core.Behaviours;

namespace Users.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(AssemblyReference.Assembly);
            configure.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly);

        var mapperConfig = TypeAdapterConfig.GlobalSettings;
        mapperConfig.Scan(AssemblyReference.Assembly);
        services.AddSingleton(mapperConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}