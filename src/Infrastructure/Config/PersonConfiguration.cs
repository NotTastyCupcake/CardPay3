using Metcom.CardPay3.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Config
{
    public class PersonConfiguration : IEntityTypeConfiguration<PersonItem>
    {
        public void Configure(EntityTypeBuilder<PersonItem> builder)
        {

            builder.Property(ci => ci.Id)
                .IsRequired();

            builder.HasOne(ci => ci.Document)
                .WithOne()
                .HasForeignKey<PersonItem>(ci => ci.IdDocument)
                .IsRequired(true);

            builder.HasOne(ci => ci.Address)
                .WithOne()
                .HasForeignKey<PersonItem>(ci => ci.IdAddress);

            builder.HasOne(ci => ci.Gender)
                .WithOne()
                .HasForeignKey<PersonItem>(ci => ci.IdGender)
                .IsRequired(true);

            builder.Property(ci => ci.LastName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.FirstName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.MiddleName)
                .IsRequired(true)
                .HasMaxLength(50);
        }
    }
}
