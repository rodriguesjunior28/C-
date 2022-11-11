using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myProject.Migrations
{
    public partial class AtualizarTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cadastros",
                table: "Cadastros");

            migrationBuilder.RenameTable(
                name: "Cadastros",
                newName: "cadastros");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Compras",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Compras",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Destino",
                table: "Compras",
                newName: "destino");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Compras",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DataCompra",
                table: "Compras",
                newName: "data_compra");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "cadastros",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "cadastros",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cadastros",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "cadastros",
                newName: "endereço");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "cadastros",
                newName: "data_nascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cadastros",
                table: "cadastros",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cadastros",
                table: "cadastros");

            migrationBuilder.RenameTable(
                name: "cadastros",
                newName: "Cadastros");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "Compras",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Compras",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "destino",
                table: "Compras",
                newName: "Destino");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Compras",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_compra",
                table: "Compras",
                newName: "DataCompra");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Cadastros",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Cadastros",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cadastros",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "endereço",
                table: "Cadastros",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "Cadastros",
                newName: "DataNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cadastros",
                table: "Cadastros",
                column: "Id");
        }
    }
}
