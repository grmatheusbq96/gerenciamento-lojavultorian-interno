using GerenciamentoVultorian.Application.Extensions;
using GerenciamentoVultorian.Infra.Persistence.Extensions;

namespace GerenciamentoVultorian.Api.Config;

public static class DependencyInjectionSetup
{
    public static WebApplicationBuilder ConfigureDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApplication();
        builder.Services.AddPersistence();

        return builder;
    }
}