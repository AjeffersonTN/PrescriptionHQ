using Microsoft.EntityFrameworkCore.Migrations;

namespace PrescriptionHQ.Migrations
{
    public partial class Script3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Refills",
                table: "Prescription",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Refills",
                table: "Prescription");
        }
    }
}
