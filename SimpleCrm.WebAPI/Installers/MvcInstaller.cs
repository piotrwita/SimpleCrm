using External.TaxpayersAPI;
using SimpleCrm.Application;
using SimpleCrm.Infrastructure;
using SimpleCrm.WebAPI.Middlewares;

namespace SimpleCrm.WebAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddApplication();
            services.AddInfrastructure();
            services.AddTaxpayersApi();

            services.AddScoped<ErrorHandlingMiddleware>();
        }
    }
}
