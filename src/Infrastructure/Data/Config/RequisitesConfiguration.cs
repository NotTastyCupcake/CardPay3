using Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class RequisitesConfiguration : IEntityTypeConfiguration<RequisitesItem>
    {
        public void Configure(EntityTypeBuilder<RequisitesItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.HasOne(ci => ci.Division)
                .WithMany()
                .HasForeignKey(ci => ci.IdDivision)
                .IsRequired(true);

            builder.HasOne(ci => ci.Currency)
                .WithMany()
                .HasForeignKey(ci => ci.IdCurrency)
                .IsRequired(true);

            builder.HasOne(ci => ci.CardType)
                .WithMany()
                .HasForeignKey(ci => ci.IdCardType)
                .IsRequired(true);

            builder.HasOne(ci => ci.Status)
                .WithMany()
                .HasForeignKey(ci => ci.IdStatus)
                .IsRequired(true);
        }
    }
}
