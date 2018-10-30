using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stock.EntityFramework;
using Stock.EntityFramework.SqlServer;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SqlServerServiceCollectionExtensions
    {
        public static IServiceCollection AddStockSqlServerEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddTnfEntityFrameworkCore()
                .AddTnfDbContext<StockDbContext, SqlServerStockDbContext>(config =>
                {
                    config.DbContextOptions.UseSqlServer(configuration.GetConnectionString("SqlServer"));
                });

            return services;
        }
    }
}
