using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CaseStudy.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    AnnualIncome = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    APR = table.Column<double>(nullable: false),
                    WelcomeMessage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}