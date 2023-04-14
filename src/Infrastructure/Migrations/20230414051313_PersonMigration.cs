using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metcom.CardPay3.Infrastructure.Migrations
{
    public partial class PersonMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "person_group_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "BankCardType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCardType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankDivision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDivision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumHome = table.Column<int>(type: "int", nullable: false),
                    NumCase = table.Column<int>(type: "int", nullable: false),
                    NumApartment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortGenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    IdDivision = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    IdCurrency = table.Column<int>(type: "int", nullable: false),
                    INN = table.Column<int>(type: "int", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatinFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatinLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    CardTypeId = table.Column<int>(type: "int", nullable: true),
                    IdCardType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisites_BankCardType_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "BankCardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisites_BankCurrency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "BankCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requisites_BankDivision_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "BankDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IdActualAddress = table.Column<int>(type: "int", nullable: false),
                    ActualAddressId = table.Column<int>(type: "int", nullable: true),
                    IdResidenceAddress = table.Column<int>(type: "int", nullable: false),
                    ResidenceAddressId = table.Column<int>(type: "int", nullable: true),
                    IdMailAddress = table.Column<int>(type: "int", nullable: false),
                    MailAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_BaseAddress_ActualAddressId",
                        column: x => x.ActualAddressId,
                        principalTable: "BaseAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_BaseAddress_MailAddressId",
                        column: x => x.MailAddressId,
                        principalTable: "BaseAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_BaseAddress_ResidenceAddressId",
                        column: x => x.ResidenceAddressId,
                        principalTable: "BaseAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    IdType = table.Column<int>(type: "int", nullable: false),
                    DataIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubdivisionCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accrual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrganization = table.Column<int>(type: "int", nullable: false),
                    IdAccruaType = table.Column<int>(type: "int", nullable: false),
                    IdOperationType = table.Column<int>(type: "int", nullable: false),
                    AccrualDay = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accrual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accrual_Operations_IdOperationType",
                        column: x => x.IdOperationType,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accrual_Organizations_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdOrganization = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Organizations_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdGender = table.Column<int>(type: "int", nullable: false),
                    IdRequisties = table.Column<int>(type: "int", nullable: false),
                    RequisitesId = table.Column<int>(type: "int", nullable: true),
                    IdDocument = table.Column<int>(type: "int", nullable: false),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    IdOrganization = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Addresses_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Documents_IdDocument",
                        column: x => x.IdDocument,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Genders_IdGender",
                        column: x => x.IdGender,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Organizations_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Requisites_RequisitesId",
                        column: x => x.RequisitesId,
                        principalTable: "Requisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupItem_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccrualItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccrualId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccrualItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccrualItems_Accrual_AccrualId",
                        column: x => x.AccrualId,
                        principalTable: "Accrual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccrualItems_People_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accrual_IdOperationType",
                table: "Accrual",
                column: "IdOperationType");

            migrationBuilder.CreateIndex(
                name: "IX_Accrual_IdOrganization",
                table: "Accrual",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_AccrualItems_AccrualId",
                table: "AccrualItems",
                column: "AccrualId");

            migrationBuilder.CreateIndex(
                name: "IX_AccrualItems_IdPerson",
                table: "AccrualItems",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ActualAddressId",
                table: "Addresses",
                column: "ActualAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MailAddressId",
                table: "Addresses",
                column: "MailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ResidenceAddressId",
                table: "Addresses",
                column: "ResidenceAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                table: "Documents",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupItem_GroupId",
                table: "GroupItem",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_IdOrganization",
                table: "Groups",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_People_IdAddress",
                table: "People",
                column: "IdAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_IdDocument",
                table: "People",
                column: "IdDocument",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_IdGender",
                table: "People",
                column: "IdGender",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_IdOrganization",
                table: "People",
                column: "IdOrganization",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_RequisitesId",
                table: "People",
                column: "RequisitesId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisites_CardTypeId",
                table: "Requisites",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisites_CurrencyId",
                table: "Requisites",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisites_DivisionId",
                table: "Requisites",
                column: "DivisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccrualItems");

            migrationBuilder.DropTable(
                name: "GroupItem");

            migrationBuilder.DropTable(
                name: "Accrual");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Requisites");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "BaseAddress");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "BankCardType");

            migrationBuilder.DropTable(
                name: "BankCurrency");

            migrationBuilder.DropTable(
                name: "BankDivision");

            migrationBuilder.DropSequence(
                name: "person_group_hilo");
        }
    }
}
