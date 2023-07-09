using Microsoft.EntityFrameworkCore.Migrations;

namespace LabClothingCollection.Migrations;

public partial class CriacaoColecoesUpdate : Migration
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
        { 1, "Harmonia Tropical", 38027368936, "Farm", 15565, new DateTime(2022, 5, 6), 0, 0 },
        { 2, "TRF", 80889794987, "Zara", 20000, new DateTime(2022, 6, 1), 1, 0 },
        { 3, "Brisa Litoral", 12547561913, "Zara", 15000, new DateTime(2022, 7, 15), 2, 1 },
        { 4, "Minimalista", 04763423924, "Mango", 18000, new DateTime(2022, 8, 10), 3, 0 },
        { 5, "LOVE", 20996384000151, "Renner", 22000, new DateTime(2022, 9, 25), 0, 0 }
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
