using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Entities
{
    public class NumberToEnglishProcessedConfiguration : IEntityTypeConfiguration<NumberToEnglishProcessed>
    {
        public void Configure(EntityTypeBuilder<NumberToEnglishProcessed> builder)
        {
            // not in the specs, but in my experience it's never a bad idea!
            builder.HasKey(n => n.NumberToEnglishHistoryId);

            builder.Property(n => n.OutputText)
                .HasMaxLength(1000)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(n => n.InputNumber)
                .HasColumnType("DECIMAL(12,12)") // BIG decimals
                .IsRequired();

            builder.Property(n => n.CreatedAt)
                .HasDefaultValueSql("getdate()")
                .IsRequired()
                .HasConversion(
                    // work around some ef core quirks
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        }
    }
}
