using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabClothingCollection.Migrations
{
    public partial class CriacaoTabelaColecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Colecao",
               columns: table => new
               {
                   IdColecao = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   NomeColecao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   IdResponsavel = table.Column<long>(type: "bigint", nullable: false),
                   Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Orcamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                   AnoLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Estacao = table.Column<int>(type: "int", nullable: false),
                   Estado = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Colecao", x => x.IdColecao);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Colecao");
        }
    }
}
