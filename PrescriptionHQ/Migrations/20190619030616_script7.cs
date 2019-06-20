using Microsoft.EntityFrameworkCore.Migrations;

namespace PrescriptionHQ.Migrations
{
    public partial class script7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Allgeries",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allgeries",
                table: "AspNetUsers");
        }
    }
}
