using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabClothingCollection.Migrations
{
    public partial class CriacaoUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "Id", "CpfCnpj", "DataNascimento", "Discriminator", "Email", "Genero", "Nome", "Status", "Telefone", "Tipo" },
                values: new object[,]
                {
                    { 1, "380.273.689-36", new DateTime(1993, 08, 31), "Usuario", "maria@example.com", "F", "Maria da Silva", "Ativo", "99819-7607", "Outro" },
                    { 2, "808.897.949-87", new DateTime(1990, 11, 25), "Usuario", "josee2@example.com", "M", "José Andrade", "Ativo", "98772-8465", "Gerente" },
                    { 3, "125.475.619-13", new DateTime(1988, 01, 06), "Usuario", "bruna@example.com", "F", "Bruna Lopez", "Ativo", "99151-3437", "Criador" },
                    { 4, "047.634.239-24", new DateTime(1981, 03, 15), "Usuario", "pedro@example.com", "M", "Pedro Assis", "Ativo", "98474-3877", "Gerente" },
                    { 5, "20996384000151", new DateTime(1992, 04, 09), "Usuario", "julia@empresa.com", "F", "Empresa Julia Ltda", "Ativo", "3278-1022", "Administrador" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
