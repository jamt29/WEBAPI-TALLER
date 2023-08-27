using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio_26_07.Migrations
{
    public partial class step5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Talleres_TallerId",
                table: "Autos");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Talleres",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "TallerId",
                table: "Autos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "TalleresAutores",
                columns: table => new
                {
                    AutoId = table.Column<int>(type: "int", nullable: false),
                    TallerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalleresAutores", x => new { x.TallerId, x.AutoId });
                    table.ForeignKey(
                        name: "FK_TalleresAutores_Autos_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Autos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TalleresAutores_Talleres_TallerId",
                        column: x => x.TallerId,
                        principalTable: "Talleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalleresAutores_AutoId",
                table: "TalleresAutores",
                column: "AutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Talleres_TallerId",
                table: "Autos",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Talleres_TallerId",
                table: "Autos");

            migrationBuilder.DropTable(
                name: "TalleresAutores");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Talleres",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "TallerId",
                table: "Autos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Talleres_TallerId",
                table: "Autos",
                column: "TallerId",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
