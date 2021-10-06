using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula03.Web.Exemplo01.Migrations
{
    public partial class Relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoraId",
                table: "Tbl_Filme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tbl_Ator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dt_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Ator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Ator_Filme",
                columns: table => new
                {
                    AtorId = table.Column<int>(type: "int", nullable: false),
                    FilmeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Ator_Filme", x => new { x.AtorId, x.FilmeId });
                    table.ForeignKey(
                        name: "FK_Tbl_Ator_Filme_Tbl_Ator_AtorId",
                        column: x => x.AtorId,
                        principalTable: "Tbl_Ator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Ator_Filme_Tbl_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Tbl_Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Produtora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Produtora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Produtora_Tbl_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Tbl_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Filme_ProdutoraId",
                table: "Tbl_Filme",
                column: "ProdutoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Ator_Filme_FilmeId",
                table: "Tbl_Ator_Filme",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Produtora_EnderecoId",
                table: "Tbl_Produtora",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Filme_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Filme",
                column: "ProdutoraId",
                principalTable: "Tbl_Produtora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Filme_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Filme");

            migrationBuilder.DropTable(
                name: "Tbl_Ator_Filme");

            migrationBuilder.DropTable(
                name: "Tbl_Produtora");

            migrationBuilder.DropTable(
                name: "Tbl_Ator");

            migrationBuilder.DropTable(
                name: "Tbl_Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Filme_ProdutoraId",
                table: "Tbl_Filme");

            migrationBuilder.DropColumn(
                name: "ProdutoraId",
                table: "Tbl_Filme");
        }
    }
}
