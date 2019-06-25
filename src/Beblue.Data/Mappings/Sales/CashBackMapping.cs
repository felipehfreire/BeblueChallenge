using Beblue.Data.Extensions;
using Beblue.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beblue.Data.Mappings.Sales
{
    class CashBackMapping : EntityTypeConfiguration<CashBack>
    {
        public override void Map(EntityTypeBuilder<CashBack> builder)
        {
            builder.ToTable("CashBack");
            builder.HasKey(e => e.Id);

            // not map ValidationResult from fluent validation
            builder.Ignore(e => e.ValidationResult);
            //to igonre cascade mode validations
            builder.Ignore(e => e.CascadeMode);
        }
    }
}
