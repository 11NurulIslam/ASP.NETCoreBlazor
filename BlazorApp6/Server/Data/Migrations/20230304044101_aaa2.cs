using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp6.Server.Data.Migrations
{
    public partial class aaa2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "masters",
                columns: table => new
                {
                    MasterPK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FK = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masters", x => x.MasterPK);
                });

            migrationBuilder.CreateTable(
                name: "details",
                columns: table => new
                {
                    DetailsPK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    otherFields = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_details", x => x.DetailsPK);
                    table.ForeignKey(
                        name: "FK_details_masters_FK",
                        column: x => x.FK,
                        principalTable: "masters",
                        principalColumn: "MasterPK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_details_FK",
                table: "details",
                column: "FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "details");

            migrationBuilder.DropTable(
                name: "masters");
        }
    }
}
