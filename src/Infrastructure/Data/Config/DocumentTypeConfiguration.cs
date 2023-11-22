using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.DocumentName)
                .IsRequired(true);

            builder
                .HasMany(c => c.Documents)
                .WithOne(e => e.Type);
        }
    }
}
