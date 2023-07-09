using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabClothingCollection.Migrations
{
    public partial class CricaoDadosColecaoModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
              table: "Colecao",
              keyColumn: "IdColecao",
              keyValues: new object[] { 1, 2, 3, 4, 5 });

            migrationBuilder.InsertData(
            table: "Colecao",
             columns: new[] { "IdColecao", "NomeColecao", "IdResponsavel", "Marca", "Orcamento", "AnoLancamento", "Estacao", "Estado" },
            values: new object[,]
        {
        { 1, "Harmonia Tropical", 0, "Farm", 15565, new DateTime(2022, 5, 6).ToString("yyyy-MM-dd"), "Outuno", "ATIVO" },
        { 2, "TRF", 0, "Zara", 20000, new DateTime(2022, 6, 1).ToString("yyyy-MM-dd"), "Inverno", "ATIVO" },
        { 3, "Brisa Litoral", 0, "Zara", 15000, new DateTime(2022, 7, 15).ToString("yyyy-MM-dd"), "Verao", "ATIVO" },
        { 4, "Minimalista", 0, "Mango", 18000, new DateTime(2022, 8, 10).ToString("yyyy-MM-dd"), "Primavera", "ATIVO" },
        { 5, "LOVE", 0, "Renner", 22000, new DateTime(2022, 9, 25).ToString("yyyy-MM-dd"), "Verao", "ATIVO" }
        });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
            table: "Colecao",
            keyColumn: "IdColecao",
            keyValues: new object[] { 1, 2, 3, 4, 5 });

        }
    }
}
