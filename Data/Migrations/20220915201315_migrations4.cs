using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominioDev.Api.Data.Migrations
{
    public partial class migrations4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orcamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GastoTotal = table.Column<double>(type: "float", nullable: false),
                    HabitanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habitantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    DataNacimento = table.Column<DateTime>(type: "date", nullable: false),
                    Renda = table.Column<double>(type: "float", nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false),
                    CustoCondominio = table.Column<double>(type: "float", nullable: false),
                    CondominioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habitantes_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitantes_CondominioId",
                table: "Habitantes",
                column: "CondominioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habitantes");

            migrationBuilder.DropTable(
                name: "Condominio");
        }
    }
}
