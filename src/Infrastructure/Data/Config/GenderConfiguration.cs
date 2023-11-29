using Metcom.CardPay3.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.GenderName)
                .IsRequired(true);

            builder.Property(ci => ci.ShortGenderName)
                .IsRequired(true);
        }
    }
}
