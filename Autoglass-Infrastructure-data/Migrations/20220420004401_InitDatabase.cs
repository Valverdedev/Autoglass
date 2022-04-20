using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoglass_Infrastructure_data.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Situacao = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataFabricacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CodigoFornecedor = table.Column<string>(type: "TEXT", nullable: true),
                    DescricaoFornecedor = table.Column<string>(type: "TEXT", nullable: true),
                    CnpjFornecedor = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
