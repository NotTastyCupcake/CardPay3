﻿// <auto-generated />
using System;
using Metcom.CardPay3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Metcom.CardPay3.Infrastructure.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20230414051313_PersonMigration")]
    partial class PersonMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.HasSequence("person_group_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate.Accrual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccrualDay")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("IdAccruaType")
                        .HasColumnType("int");

                    b.Property<int>("IdOperationType")
                        .HasColumnType("int");

                    b.Property<int>("IdOrganization")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOperationType");

                    b.HasIndex("IdOrganization");

                    b.ToTable("Accrual");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate.AccrualItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccrualId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccrualId");

                    b.HasIndex("IdPerson");

                    b.ToTable("AccrualItems");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate.OperationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualAddressId")
                        .HasColumnType("int");

                    b.Property<int>("IdActualAddress")
                        .HasColumnType("int");

                    b.Property<int>("IdMailAddress")
                        .HasColumnType("int");

                    b.Property<int>("IdResidenceAddress")
                        .HasColumnType("int");

                    b.Property<int?>("MailAddressId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("ResidenceAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActualAddressId");

                    b.HasIndex("MailAddressId");

                    b.HasIndex("ResidenceAddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate.BaseAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumApartment")
                        .HasColumnType("int");

                    b.Property<int>("NumCase")
                        .HasColumnType("int");

                    b.Property<int>("NumHome")
                        .HasColumnType("int");

                    b.Property<int>("Postcode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BaseAddress");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate.DocumentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataIssued")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdType")
                        .HasColumnType("int");

                    b.Property<string>("IssuedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubdivisionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DocumentType");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "person_group_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("IdOrganization")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdOrganization");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate.GroupItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupItem");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.PersonGender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortGenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.PersonItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdAddress")
                        .HasColumnType("int");

                    b.Property<int>("IdDocument")
                        .HasColumnType("int");

                    b.Property<int>("IdGender")
                        .HasColumnType("int");

                    b.Property<int>("IdOrganization")
                        .HasColumnType("int");

                    b.Property<int>("IdRequisties")
                        .HasColumnType("int");

                    b.Property<string>("JobPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequisitesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAddress")
                        .IsUnique();

                    b.HasIndex("IdDocument")
                        .IsUnique();

                    b.HasIndex("IdGender")
                        .IsUnique();

                    b.HasIndex("IdOrganization")
                        .IsUnique();

                    b.HasIndex("RequisitesId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.PersonOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate.BankCardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankCardType");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate.BankCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankCurrency");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate.BankDivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DivisionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankDivision");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate.RequisitesItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CardTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("int");

                    b.Property<int>("INN")
                        .HasColumnType("int");

                    b.Property<int>("IdCardType")
                        .HasColumnType("int");

                    b.Property<int>("IdCurrency")
                        .HasColumnType("int");

                    b.Property<int>("IdDivision")
                        .HasColumnType("int");

                    b.Property<string>("InsuranceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatinFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatinLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DivisionId");

                    b.ToTable("Requisites");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate.Accrual", b =>
                {
                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate.OperationType", "OperationType")
                        .WithMany()
                        .HasForeignKey("IdOperationType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.PersonOrganization", "Organization")
                        .WithMany()
                        .HasForeignKey("IdOrganization")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationType");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate.AccrualItem", b =>
                {
                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate.Accrual", null)
                        .WithMany("Items")
                        .HasForeignKey("AccrualId");

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.PersonItem", "Person")
                        .WithMany()
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate.Address", b =>
                {
                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate.BaseAddress", "ActualAddress")
                        .WithMany()
                        .HasForeignKey("ActualAddressId");

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate.BaseAddress", "MailAddress")
                        .WithMany()
                        .HasForeignKey("MailAddressId");

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate.BaseAddress", "ResidenceAddress")
                        .WithMany()
                        .HasForeignKey("ResidenceAddressId");

                    b.Navigation("ActualAddress");

                    b.Navigation("MailAddress");

                    b.Navigation("ResidenceAddress");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate.DocumentItem", b =>
                {
                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate.DocumentType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate.Group", b =>
                {
                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.PersonOrganization", "Organization")
                        .WithMany()
                        .HasForeignKey("IdOrganization")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate.GroupItem", b =>
                {
                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate.Group", null)
                        .WithMany("Items")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.PersonItem", b =>
                {
                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate.Address", "Address")
                        .WithOne()
                        .HasForeignKey("Metcom.CardPay3.ApplicationCore.Entities.PersonItem", "IdAddress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.DocumentAggregate.DocumentItem", "Document")
                        .WithOne()
                        .HasForeignKey("Metcom.CardPay3.ApplicationCore.Entities.PersonItem", "IdDocument")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.PersonGender", "Gender")
                        .WithOne()
                        .HasForeignKey("Metcom.CardPay3.ApplicationCore.Entities.PersonItem", "IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.PersonOrganization", "Organization")
                        .WithOne()
                        .HasForeignKey("Metcom.CardPay3.ApplicationCore.Entities.PersonItem", "IdOrganization")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate.RequisitesItem", "Requisites")
                        .WithMany()
                        .HasForeignKey("RequisitesId");

                    b.Navigation("Address");

                    b.Navigation("Document");

                    b.Navigation("Gender");

                    b.Navigation("Organization");

                    b.Navigation("Requisites");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate.RequisitesItem", b =>
                {
                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate.BankCardType", "CardType")
                        .WithMany()
                        .HasForeignKey("CardTypeId");

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate.BankCurrency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("Metcom.CardPay3.ApplicationCore.Entities.RequisitesAggtegate.BankDivision", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId");

                    b.Navigation("CardType");

                    b.Navigation("Currency");

                    b.Navigation("Division");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.AccrualAggregate.Accrual", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Metcom.CardPay3.ApplicationCore.Entities.GroupAggregate.Group", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
