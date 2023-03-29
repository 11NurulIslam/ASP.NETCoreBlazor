using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp6.Server.Data.Migrations
{
    public partial class aaa3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Appointment_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Appointment_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Appointment_ID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Service_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Service_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appointment_ID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Service_Fee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Service_ID);
                    table.ForeignKey(
                        name: "FK_Service_Appointment_Appointment_ID",
                        column: x => x.Appointment_ID,
                        principalTable: "Appointment",
                        principalColumn: "Appointment_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_Appointment_ID",
                table: "Service",
                column: "Appointment_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
