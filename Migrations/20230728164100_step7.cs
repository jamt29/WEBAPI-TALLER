using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio_26_07.Migrations
{
    public partial class step7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Talleres_TallerId",
                table: "Autos");

            migrationBuilder.DropIndex(
                name: "IX_Autos_TallerId",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "TallerId",
                table: "Autos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TallerId",
                table: "Autos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autos_TallerId",
                table: "Autos",
                column: "TallerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Talleres_TallerId",
                table: "Autos",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id");
        }
    }
}
