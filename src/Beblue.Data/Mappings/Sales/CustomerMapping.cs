using Beblue.Data.Extensions;
using Beblue.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beblue.Data.Mappings.Sales
{
    class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
               .HasColumnType("varchar(200)")
               .IsRequired();

            // not map ValidationResult from fluent validation
            builder.Ignore(e => e.ValidationResult);
            //to igonre cascade mode validations
            builder.Ignore(e => e.CascadeMode);
        }
    }
}
