using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Automovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAutomovel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cor = table.Column<string>(type: "varchar(30)", nullable: false),
                    Combustivel = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "varchar(8)", nullable: false),
                    QntdCombustivel = table.Column<int>(type: "int", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "varchar(25)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(45)", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    Alugado = table.Column<bool>(type: "bit", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automovel_GrupoAutomoveis",
                        column: x => x.CategoriaId,
                        principalTable: "TBGrupoAutomoveis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_CategoriaId",
                table: "TBAutomovel",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAutomovel");
        }
    }
}
