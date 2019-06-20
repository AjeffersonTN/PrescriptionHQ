using Microsoft.EntityFrameworkCore.Migrations;

namespace PrescriptionHQ.Migrations
{
    public partial class script6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefillRequested",
                table: "Prescription",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "RefillRequested",
                table: "Prescription",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
