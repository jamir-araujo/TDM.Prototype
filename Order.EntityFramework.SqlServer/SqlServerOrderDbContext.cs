using Microsoft.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace Ordering.EntityFramework.SqlServer
{
    public class SqlServerOrderDbContext : OrderDbContext
    {
        public SqlServerOrderDbContext(DbContextOptions<OrderDbContext> options, ITnfSession session) 
            : base(options, session)
        {
        }
    }
}
