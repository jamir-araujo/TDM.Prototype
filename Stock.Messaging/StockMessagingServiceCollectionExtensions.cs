using Microsoft.Extensions.Configuration;
using SharedKernel;
using Stock.Messaging;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StockMessagingServiceCollectionExtensions
    {
        public static IServiceCollection AddStockMessaging(this IServiceCollection services)
        {
            services.AddTnfBusClient();
            services.AddSingleton<IEventBus, EventBus>();

            return services;
        }
    }
}
