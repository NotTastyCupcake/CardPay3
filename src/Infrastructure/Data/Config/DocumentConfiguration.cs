using Metcom.CardPay3.ApplicationCore.Entities;
using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class DocumentConfiguration : IEntityTypeConfiguration<DocumentItem>
    {

        public void Configure(EntityTypeBuilder<DocumentItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.HasOne(ci => ci.Type)
                .WithMany(e => e.Documents)
                .HasForeignKey(d => d.IdType)
                .IsRequired(true);

            //builder.HasMany<Employee>()
            //    .WithOne(on => on.Organization)
            //    .HasForeignKey(ci => ci.IdOrganization)
            //    .IsRequired(true)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
