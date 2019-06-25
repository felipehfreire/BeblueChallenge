using Beblue.Data.Extensions;
using Beblue.Domain.Discs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beblue.Data.Mappings.Discs
{
    class DiscMapping : EntityTypeConfiguration<Disc>
    {
        public override void Map(EntityTypeBuilder<Disc> builder)
        {
            builder.ToTable("Discs");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();
            builder.Property(e => e.Genre)
                .HasColumnType("varchar(150)")
                .IsRequired();

            // not map ValidationResult from fluent validation
            builder.Ignore(e => e.ValidationResult);
            //to igonre cascade mode validations
            builder.Ignore(e => e.CascadeMode);
        }
    }
}
