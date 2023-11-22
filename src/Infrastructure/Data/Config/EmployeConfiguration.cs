﻿using Metcom.CardPay3.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metcom.CardPay3.Infrastructure.Data.Config
{
    public class EmployeConfiguration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.HasOne(ci => ci.Document)
                .WithOne()
                .HasForeignKey<Employe>(ci => ci.IdDocument)
                .IsRequired(true);
            builder.Property(ci => ci.IdDocument)
                .ValueGeneratedOnAdd();

            builder.HasMany(ci => ci.Addresses)
                .WithOne(ci => ci.Employer)
                .HasForeignKey(ci => ci.IdEmployer)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Gender)
                .WithMany()
                .HasForeignKey(ci => ci.IdGender)
                .IsRequired(true);

            builder.HasMany(ci => ci.Requisites)
                .WithOne(ci => ci.Employer)
                .HasForeignKey(ci => ci.IdEmployer)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Organization)
                .WithMany(o => o.Employes)
                .HasForeignKey(ci => ci.IdOrganization)
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
