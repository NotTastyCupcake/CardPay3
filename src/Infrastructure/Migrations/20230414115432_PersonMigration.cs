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
                    IdDivision = table.Column<int>(type: "int", nullable: false),
                    IdCurrency = table.Column<int>(type: "int", nullable: false),
                    INN = table.Column<int>(type: "int", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatinFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatinLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    IdCardType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisites_BankCardType_IdCardType",
                        column: x => x.IdCardType,
                        principalTable: "BankCardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisites_BankCurrency_IdCurrency",
                        column: x => x.IdCurrency,
                        principalTable: "BankCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisites_BankDivision_IdDivision",
                        column: x => x.IdDivision,
                        principalTable: "BankDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdType = table.Column<int>(type: "int", nullable: false),
                    DataIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubdivisionCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentType_IdType",
                        column: x => x.IdType,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IdDocument = table.Column<int>(type: "int", nullable: false),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    IdOrganization = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
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
                        name: "FK_People_Requisites_IdRequisties",
                        column: x => x.IdRequisties,
                        principalTable: "Requisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_People_IdPerson",
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
                name: "IX_Addresses_IdPerson",
                table: "Addresses",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IdType",
                table: "Documents",
                column: "IdType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupItem_GroupId",
                table: "GroupItem",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_IdOrganization",
                table: "Groups",
                column: "IdOrganization");

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
                name: "IX_People_IdRequisties",
                table: "People",
                column: "IdRequisties",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requisites_IdCardType",
                table: "Requisites",
                column: "IdCardType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requisites_IdCurrency",
                table: "Requisites",
                column: "IdCurrency",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requisites_IdDivision",
                table: "Requisites",
                column: "IdDivision",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccrualItems");

            migrationBuilder.DropTable(
                name: "Addresses");

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
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Requisites");

            migrationBuilder.DropTable(
                name: "Organizations");

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
