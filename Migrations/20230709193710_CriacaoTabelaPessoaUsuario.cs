using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabClothingCollection.Migrations
{
    public partial class CriacaoTabelaPessoaUsuario : Migration
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
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colecao",
                columns: table => new
                {
                    IdColecao = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    NomeColecao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdResponsavel = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Orcamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnoLancamento = table.Column<DateTime>(type: "date", nullable: false),
                    Estacao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecao", x => x.IdColecao);
                    table.ForeignKey(
                        name: "FK_Colecao_Pessoa_Id",
                        column: x => x.IdResponsavel,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    IdModelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColecaoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.IdModelo);
                    table.ForeignKey(
                        name: "FK_Modelos_Colecao_IdColecao",
                        column: x => x.ColecaoId,
                        principalTable: "Colecao",
                        principalColumn: "IdColecao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "Id", "Nome", "Genero", "DataNascimento", "CpfCnpj", "Telefone","Email", "Tipo", "Status", "Discriminator" },
                values: new object[,]
                {
                    { 1, "Maria da Silva","F", new DateTime(1993-08-31), "38027368936","99819-7607","maria@example.com", "Administrador","ATIVO", "Usuario" },
                    { 2, "José Andrade", "M", new DateTime(1990-01-12), "80889794987","98772-8465", "josee2@example.com", "Gerente", "ATIVO", "Usuario"  },
                    { 3, "Bruna Lopez", "F",new DateTime(1989-05-06),"12547561913", "99151-3437", "bruna@example.com", "Criador", "ATIVO", "Usuario"  },
                    { 4, "Pedro Assis", "M", new DateTime(1981-12-05), "04763423924", "98474-3877", "pedro@example.com",  "Outro", "ATIVO", "Usuario"  },
                    { 5, "Empresa Julia Ltda", "F", new DateTime(1996-10-07), "20996384000151", "3278-1022" ,"julia@empresa.com", "Administrador", "ATIVO", "Usuario"  }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdColecao",
                table: "Modelos",
                column: "ColecaoId");

            migrationBuilder.CreateIndex(
                name: "IdResposavel",
                table: "Pessoa",
                column: "CpfCnpj",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Colecao");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
