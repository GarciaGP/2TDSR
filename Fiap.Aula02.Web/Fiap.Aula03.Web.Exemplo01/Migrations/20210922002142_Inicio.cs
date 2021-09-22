using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula03.Web.Exemplo01.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Sinopse = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Data_Lancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Maior_Idade = table.Column<bool>(type: "bit", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Filme", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Filme");
        }
    }
}
