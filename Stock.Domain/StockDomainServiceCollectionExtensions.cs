using Stock.Domain.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StockDomainServiceCollectionExtensions
    {
        public static IServiceCollection AddStockDomain(this IServiceCollection services)
        {
            services.AddTnfDomain();
            services.AddSingleton<IProductService, ProductService>();

            return services;
        }
    }
}
