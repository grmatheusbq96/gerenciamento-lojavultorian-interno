using GerenciamentoVultorian.Domain.Interfaces.Repositories;
using GerenciamentoVultorian.Infra.Persistence.Contexts;
using GerenciamentoVultorian.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoVultorian.Infra.Persistence.Extensions;

public static class PersistenceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<VultorianContext>((provider, options) =>
        {
            options.UseSqlServer(
                provider.GetRequiredService<IConfiguration>()
                .GetConnectionString("VultorianContext"));
        });

        services.AddScoped<IClienteRepository, ClienteRepository>();

        return services;
    }
}