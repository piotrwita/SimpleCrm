using External.TaxpayersAPI.External;
using External.TaxpayersAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace External.TaxpayersAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTaxpayersApi(this IServiceCollection services)
        {
            services.AddScoped<IVatWhiteListRepository>(x =>
                new VatWhiteListRepository(new HttpClient()));

            services.AddScoped<ITaxpayerListApiClient, TaxpayerListApiClient>();

            return services;
        }
    }
}
