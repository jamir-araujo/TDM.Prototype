using System;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Model;
using Tnf.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace Ordering.EntityFramework
{
    public class OrderDbContext : TnfDbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options, ITnfSession session) 
            : base(options, session)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Items);

                entity.Ignore(e => e.UnpublishedEvents);
            });

            modelBuilder.Entity<OrderItem>(entity => 
            {
                entity.HasKey(e => e.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
