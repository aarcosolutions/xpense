using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace xpense.Repository.Migrations
{
    public partial class InitializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    OrganisationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyNumber = table.Column<string>(maxLength: 10, nullable: false),
                    CreatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    IncorporationDate = table.Column<DateTime>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Key = table.Column<Guid>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PayeReference = table.Column<string>(maxLength: 30, nullable: true),
                    PayeTaxOfficeReference = table.Column<string>(maxLength: 30, nullable: true),
                    RegisteredAddress = table.Column<string>(maxLength: 500, nullable: true),
                    UniqueTaxpayerReference = table.Column<string>(maxLength: 15, nullable: true),
                    VatNumber = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.OrganisationId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DateOfJoining = table.Column<DateTime>(nullable: false),
                    DateOfLeaving = table.Column<DateTime>(nullable: false),
                    EmployeeNumber = table.Column<string>(maxLength: 15, nullable: false),
                    FirstName = table.Column<string>(maxLength: 75, nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    Key = table.Column<Guid>(nullable: false),
                    LastName = table.Column<string>(maxLength: 75, nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<long>(nullable: true),
                    NiNumber = table.Column<string>(maxLength: 20, nullable: false),
                    OrganisationId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContactDetail",
                columns: table => new
                {
                    EmployeeContactDetailId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(maxLength: 255, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 255, nullable: false),
                    CityId = table.Column<long>(nullable: true),
                    ContactType = table.Column<int>(nullable: false),
                    CountryId = table.Column<long>(nullable: true),
                    CountyId = table.Column<long>(nullable: true),
                    Email = table.Column<string>(maxLength: 75, nullable: true),
                    EmployeeId = table.Column<long>(nullable: false),
                    Fax = table.Column<string>(maxLength: 75, nullable: true),
                    Key = table.Column<Guid>(nullable: false),
                    Phone1 = table.Column<string>(maxLength: 75, nullable: true),
                    Phone2 = table.Column<string>(maxLength: 10, nullable: true),
                    PostCode = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContactDetail", x => x.EmployeeContactDetailId);
                    table.ForeignKey(
                        name: "FK_EmployeeContactDetail_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OrganisationId",
                table: "Employee",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContactDetail_EmployeeId",
                table: "EmployeeContactDetail",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeContactDetail");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Organisation");
        }
    }
}
