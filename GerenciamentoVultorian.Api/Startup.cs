using GerenciamentoVultorian.Api.Config;

namespace GerenciamentoVultorian.Api
{
    public static class Startup
    {
        public static WebApplication Config(this string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            DependencyInjectionSetup.ConfigureDependencyInjection(builder);

            var app = builder.Build();
            AppConfiguration.ConfigureApp(app);

            return app;
        }
    }
}