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
    public class EmployeConfiguration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {

            builder.HasOne(ci => ci.Document)
                .WithOne()
                .HasForeignKey<Employe>(ci => ci.IdDocument)
                .IsRequired(true);

            builder.HasMany(ci => ci.Addresses)
                .WithOne(ci => ci.Employer)
                .HasForeignKey(ci => ci.IdEmployer)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Gender)
                .WithOne()
                .HasForeignKey<Employe>(ci => ci.IdGender)
                .IsRequired(true);

            builder.HasMany(ci => ci.Requisites)
                .WithOne(ci => ci.Employer)
                .HasForeignKey(ci => ci.IdEmployer)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(ci => ci.Organization)
                .WithOne()
                .HasForeignKey<Employe>(ci => ci.IdOrganization)
                .IsRequired(false);

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
