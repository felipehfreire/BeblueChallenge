using Beblue.Data.Extensions;
using Beblue.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beblue.Data.Mappings.Sales
{
    class OrderItemMapping : EntityTypeConfiguration<OrderItem>
    {
        public override void Map(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(e => e.Id);

            builder.HasOne(b => b.Disc)
                .WithMany()
                .HasForeignKey(c => c.DiscId);

            builder.HasOne(b => b.CashBack)
                .WithMany()
                .HasForeignKey(c => c.CashBackId);

            builder.HasOne(b => b.Sale)
                .WithMany()
                .HasForeignKey(c => c.SaleId);

            // not map ValidationResult from fluent validation
            builder.Ignore(e => e.ValidationResult);
            //to igonre cascade mode validations
            builder.Ignore(e => e.CascadeMode);
        }
    }
}
