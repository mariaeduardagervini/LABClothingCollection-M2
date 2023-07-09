using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabClothingCollection.Migrations
{
    public partial class CriacaoEAlteracaoDadosTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "UQ__Pessoa__0BCA032AACBB2372",
                table: "Pessoa",
                newName: "Identificador");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "ATIVO");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "ATIVO");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "ATIVO");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "ATIVO");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: "ATIVO");

       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "Identificador",
                table: "Pessoa",
                newName: "UQ__Pessoa__0BCA032AACBB2372");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: "Ativo");
            
        }
    }
}
