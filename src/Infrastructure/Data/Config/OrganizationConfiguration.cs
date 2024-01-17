using Metcom.CardPay3.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(on => on.Name)
                .IsRequired(true);

            builder.Property(on => on.CreateDate)
                .IsRequired(true);

            builder.Property(on => on.ApplicationNumber)
                .IsRequired(true);

            builder.Property(on => on.SourceId)
                .IsRequired(true);

            builder.HasMany(on => on.Employes)
                .WithOne(on => on.Organization)
                .HasForeignKey(ci => ci.IdOrganization)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
