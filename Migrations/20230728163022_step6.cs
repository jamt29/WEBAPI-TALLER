using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio_26_07.Migrations
{
    public partial class step6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TalleresAutores_Autos_AutoId",
                table: "TalleresAutores");

            migrationBuilder.DropForeignKey(
                name: "FK_TalleresAutores_Talleres_TallerId",
                table: "TalleresAutores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TalleresAutores",
                table: "TalleresAutores");

            migrationBuilder.RenameTable(
                name: "TalleresAutores",
                newName: "TalleresAutos");

            migrationBuilder.RenameIndex(
                name: "IX_TalleresAutores_AutoId",
                table: "TalleresAutos",
                newName: "IX_TalleresAutos_AutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TalleresAutos",
                table: "TalleresAutos",
                columns: new[] { "TallerId", "AutoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TalleresAutos_Autos_AutoId",
                table: "TalleresAutos",
                column: "AutoId",
                principalTable: "Autos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalleresAutos_Talleres_TallerId",
                table: "TalleresAutos",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TalleresAutos_Autos_AutoId",
                table: "TalleresAutos");

            migrationBuilder.DropForeignKey(
                name: "FK_TalleresAutos_Talleres_TallerId",
                table: "TalleresAutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TalleresAutos",
                table: "TalleresAutos");

            migrationBuilder.RenameTable(
                name: "TalleresAutos",
                newName: "TalleresAutores");

            migrationBuilder.RenameIndex(
                name: "IX_TalleresAutos_AutoId",
                table: "TalleresAutores",
                newName: "IX_TalleresAutores_AutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TalleresAutores",
                table: "TalleresAutores",
                columns: new[] { "TallerId", "AutoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TalleresAutores_Autos_AutoId",
                table: "TalleresAutores",
                column: "AutoId",
                principalTable: "Autos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalleresAutores_Talleres_TallerId",
                table: "TalleresAutores",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
