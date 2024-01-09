using Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
                .IsRequired(true);

            builder
                .HasMany(c => c.Documents)
                .WithOne(e => e.Type);
        }
    }
}
