using Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class AccrualItemConfiguration : IEntityTypeConfiguration<AccrualItem>
    {
        public void Configure(EntityTypeBuilder<AccrualItem> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder.Property(bi => bi.Amount)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");

            builder.Property(bi => bi.Date)
                .IsRequired(true);

            builder.HasOne(ci => ci.Employer)
                .WithMany()
                .HasForeignKey(ci => ci.IdEmployer);
        }
    }
}
