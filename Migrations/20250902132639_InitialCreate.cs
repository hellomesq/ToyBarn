﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrinquedosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brinquedos",
                columns: table => new
                {
                    Id_brinquedo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome_brinquedo = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo_brinquedo = table.Column<string>(type: "TEXT", nullable: false),
                    Classificacao = table.Column<string>(type: "TEXT", nullable: false),
                    Tamanho = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brinquedos", x => x.Id_brinquedo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brinquedos");
        }
    }
}
