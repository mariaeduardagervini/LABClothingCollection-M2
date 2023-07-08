using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabClothingCollection.Migrations
{
    public partial class CriacaoTabelaPessoaeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Genero = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    CpfCnpj = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Pessoa__0BCA032AACBB2372",
                table: "Pessoa",
                column: "CpfCnpj",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
