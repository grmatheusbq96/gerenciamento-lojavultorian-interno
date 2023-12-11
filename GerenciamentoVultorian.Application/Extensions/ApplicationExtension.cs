using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GerenciamentoVultorian.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}