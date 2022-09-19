using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominioDev.Api.Data.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CondominioId1",
                table: "Habitantes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Condominio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GastoTotal", "Orcamento" },
                values: new object[] { 700.0, 1200m });

            migrationBuilder.CreateIndex(
                name: "IX_Habitantes_CondominioId1",
                table: "Habitantes",
                column: "CondominioId1",
                unique: true,
                filter: "[CondominioId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitantes_Condominio_CondominioId1",
                table: "Habitantes",
                column: "CondominioId1",
                principalTable: "Condominio",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitantes_Condominio_CondominioId1",
                table: "Habitantes");

            migrationBuilder.DropIndex(
                name: "IX_Habitantes_CondominioId1",
                table: "Habitantes");

            migrationBuilder.DropColumn(
                name: "CondominioId1",
                table: "Habitantes");

            migrationBuilder.UpdateData(
                table: "Condominio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GastoTotal", "Orcamento" },
                values: new object[] { 0.0, 0m });
        }
    }
}
