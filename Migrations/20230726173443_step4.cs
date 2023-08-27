using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio_26_07.Migrations
{
    public partial class step4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Talleres_TallerId1",
                table: "Autos");

            migrationBuilder.DropIndex(
                name: "IX_Autos_TallerId1",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "TallerId1",
                table: "Autos");

            migrationBuilder.AlterColumn<int>(
                name: "TallerId",
                table: "Autos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_TallerId",
                table: "Autos",
                column: "TallerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Talleres_TallerId",
                table: "Autos",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Talleres_TallerId",
                table: "Autos");

            migrationBuilder.DropIndex(
                name: "IX_Autos_TallerId",
                table: "Autos");

            migrationBuilder.AlterColumn<string>(
                name: "TallerId",
                table: "Autos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TallerId1",
                table: "Autos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Autos_TallerId1",
                table: "Autos",
                column: "TallerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Talleres_TallerId1",
                table: "Autos",
                column: "TallerId1",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
