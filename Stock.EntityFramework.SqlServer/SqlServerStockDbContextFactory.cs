using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tnf.Runtime.Session;

namespace Stock.EntityFramework.SqlServer
{
    public class SqlServerStockDbContextFactory : IDesignTimeDbContextFactory<SqlServerStockDbContext>
    {
        public SqlServerStockDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<StockDbContext>();

            builder.UseSqlServer("Data Source=127.0.0.1,1433;Database=Stock;User Id=sa;Password=Totvs@pass0001;MultipleActiveResultSets=true");

            return new SqlServerStockDbContext(builder.Options, NullTnfSession.Instance);
        }
    }
}
