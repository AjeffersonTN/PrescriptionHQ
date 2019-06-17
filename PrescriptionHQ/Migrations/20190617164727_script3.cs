using Microsoft.EntityFrameworkCore.Migrations;

namespace PrescriptionHQ.Migrations
{
    public partial class script3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Prescription",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Prescription");
        }
    }
}
