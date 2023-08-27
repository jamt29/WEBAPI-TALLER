using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio_26_07.Migrations
{
    public partial class step3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Talleres_TallerId1",
                table: "Autos");

            migrationBuilder.AlterColumn<int>(
                name: "TallerId1",
                table: "Autos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Talleres_TallerId1",
                table: "Autos",
                column: "TallerId1",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Talleres_TallerId1",
                table: "Autos");

            migrationBuilder.AlterColumn<int>(
                name: "TallerId1",
                table: "Autos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Talleres_TallerId1",
                table: "Autos",
                column: "TallerId1",
                principalTable: "Talleres",
                principalColumn: "Id");
        }
    }
}
