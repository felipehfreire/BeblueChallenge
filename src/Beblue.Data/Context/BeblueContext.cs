using Beblue.Data.Extensions;
using Beblue.Data.Mappings.Discs;
using Beblue.Data.Mappings.Sales;
using Beblue.Domain.Discs;
using Beblue.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Beblue.Data.Context
{
    public class BeblueContext : DbContext
    {
        public DbSet<Disc> Discs { get; set; }
        public DbSet<CashBack> CashBacks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new DiscMapping());
            modelBuilder.AddConfiguration(new CashBackMapping());
            modelBuilder.AddConfiguration(new CustomerMapping());
            modelBuilder.AddConfiguration(new SaleMapping());
            modelBuilder.AddConfiguration(new OrderItemMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
