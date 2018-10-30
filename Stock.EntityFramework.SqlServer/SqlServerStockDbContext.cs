using Microsoft.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace Stock.EntityFramework.SqlServer
{
    public class SqlServerStockDbContext : StockDbContext
    {
        public SqlServerStockDbContext(DbContextOptions<StockDbContext> options, ITnfSession session)
            : base(options, session)
        {
        }
    }
}
