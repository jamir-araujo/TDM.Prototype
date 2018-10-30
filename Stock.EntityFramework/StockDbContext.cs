using Microsoft.EntityFrameworkCore;
using Stock.Domain.Model;
using Tnf.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace Stock.EntityFramework
{
    public class StockDbContext : TnfDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public StockDbContext(DbContextOptions<StockDbContext> options, ITnfSession session)
            : base(options, session)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product =>
            {
                product.HasKey(p => p.Id);

                product.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Reservation>(reservation =>
            {
                reservation.Property(r => r.OrderId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
