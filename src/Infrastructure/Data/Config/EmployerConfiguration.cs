using Metcom.CardPay3.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {

            builder.HasOne(ci => ci.Document)
                .WithOne()
                .HasForeignKey<Employer>(ci => ci.IdDocument)
                .IsRequired(true);

            builder.HasMany(ci => ci.Addresses)
                .WithOne(ci => ci.Employer)
                .HasForeignKey(ci => ci.IdEmployer)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Gender)
                .WithOne()
                .HasForeignKey<Employer>(ci => ci.IdGender)
                .IsRequired(true);

            builder.HasOne(ci => ci.Organization)
                .WithOne()
                .HasForeignKey<Employer>(ci => ci.IdOrganization)
                .IsRequired(true);

            builder.HasOne(ci => ci.Requisites)
                .WithOne()
                .HasForeignKey<Employer>(ci => ci.IdRequisties)
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
