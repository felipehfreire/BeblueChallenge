using Beblue.Data.Extensions;
using Beblue.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beblue.Data.Mappings.Sales
{
    class SaleMapping : EntityTypeConfiguration<Sale>
    {
        public override void Map(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");
            builder.HasKey(e => e.Id);

            builder.HasOne(b => b.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId);
                    
            builder.HasMany(c => c.Items)
               .WithOne(c => c.Sale)
               .HasForeignKey(c => c.SaleId);

            // not map ValidationResult from fluent validation
            builder.Ignore(e => e.ValidationResult);
            //to igonre cascade mode validations
            builder.Ignore(e => e.CascadeMode);
        }
    }
}
