using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseStudy.Migrations
{
    public partial class ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Applicants",
                newName: "CreditCardName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreditCardName",
                table: "Applicants",
                newName: "Name");
        }
    }
}