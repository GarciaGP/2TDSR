using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula03.Web.Exemplo01.Migrations
{
    public partial class Relacionamentos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Filme_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Filme");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoraId",
                table: "Tbl_Filme",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Filme_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Filme",
                column: "ProdutoraId",
                principalTable: "Tbl_Produtora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Filme_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Filme");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoraId",
                table: "Tbl_Filme",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Filme_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Filme",
                column: "ProdutoraId",
                principalTable: "Tbl_Produtora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
