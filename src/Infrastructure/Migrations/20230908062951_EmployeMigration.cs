using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metcom.CardPay3.Infrastructure.Migrations
{
    public partial class EmployeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "employer_group_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
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
                        name: "FK_Documents_DocumentTypes_IdType",
                        column: x => x.IdType,
                        principalTable: "DocumentTypes",
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
                    AccrualDay = table.Column<DateTime>(type: "datetime2", maxLength: 3, nullable: false)
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
                name: "Employers",
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
                    IdDocument = table.Column<int>(type: "int", nullable: false),
                    IdOrganization = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_Documents_IdDocument",
                        column: x => x.IdDocument,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employers_Genders_IdGender",
                        column: x => x.IdGender,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employers_Organizations_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupItem_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccrualItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmployer = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccrualItems_Employers_IdEmployer",
                        column: x => x.IdEmployer,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmployer = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Addresses_Employers_IdEmployer",
                        column: x => x.IdEmployer,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmployer = table.Column<int>(type: "int", nullable: true),
                    IdDivision = table.Column<int>(type: "int", nullable: false),
                    IdCurrency = table.Column<int>(type: "int", nullable: false),
                    INN = table.Column<int>(type: "int", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatinFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatinLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCardType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisites_Banks_IdDivision",
                        column: x => x.IdDivision,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisites_CardTypes_IdCardType",
                        column: x => x.IdCardType,
                        principalTable: "CardTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisites_Currencies_IdCurrency",
                        column: x => x.IdCurrency,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisites_Employers_IdEmployer",
                        column: x => x.IdEmployer,
                        principalTable: "Employers",
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
                name: "IX_AccrualItems_IdEmployer",
                table: "AccrualItems",
                column: "IdEmployer");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IdEmployer",
                table: "Addresses",
                column: "IdEmployer");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IdType",
                table: "Documents",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_IdDocument",
                table: "Employers",
                column: "IdDocument",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employers_IdGender",
                table: "Employers",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_IdOrganization",
                table: "Employers",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_GroupItem_GroupId",
                table: "GroupItem",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_IdOrganization",
                table: "Groups",
                column: "IdOrganization");

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

            migrationBuilder.CreateIndex(
                name: "IX_Requisites_IdEmployer",
                table: "Requisites",
                column: "IdEmployer");
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
                name: "Requisites");

            migrationBuilder.DropTable(
                name: "Accrual");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropSequence(
                name: "employer_group_hilo");
        }
    }
}
