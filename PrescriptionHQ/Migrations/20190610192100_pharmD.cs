using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrescriptionHQ.Migrations
{
    public partial class pharmD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PharmacyId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_PharmacyId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Phone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_State",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_StreetAddress",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_ZipCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    PharmacyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.PharmacyId);
                });

            migrationBuilder.CreateTable(
                name: "Refill",
                columns: table => new
                {
                    RefillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    PickupStatus = table.Column<bool>(nullable: false),
                    PharmacyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refill", x => x.RefillId);
                    table.ForeignKey(
                        name: "FK_Refill_Pharmacy_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacy",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Drug = table.Column<string>(nullable: false),
                    Dosage = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Frequency = table.Column<string>(nullable: false),
                    DateFilled = table.Column<DateTime>(nullable: false),
                    DatePrescribed = table.Column<DateTime>(nullable: false),
                    SpecialInstructions = table.Column<string>(nullable: true),
                    DoctorId = table.Column<string>(nullable: true),
                    RefillId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescription_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Refill_RefillId",
                        column: x => x.RefillId,
                        principalTable: "Refill",
                        principalColumn: "RefillId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PharmacyId",
                table: "AspNetUsers",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_User_PharmacyId",
                table: "AspNetUsers",
                column: "User_PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DoctorId",
                table: "Prescription",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_RefillId",
                table: "Prescription",
                column: "RefillId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_UserId",
                table: "Prescription",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Refill_PharmacyId",
                table: "Refill",
                column: "PharmacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pharmacy_PharmacyId",
                table: "AspNetUsers",
                column: "PharmacyId",
                principalTable: "Pharmacy",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pharmacy_User_PharmacyId",
                table: "AspNetUsers",
                column: "User_PharmacyId",
                principalTable: "Pharmacy",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pharmacy_PharmacyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pharmacy_User_PharmacyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Refill");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PharmacyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_User_PharmacyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PharmacyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_PharmacyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_StreetAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_ZipCode",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);
        }
    }
}
