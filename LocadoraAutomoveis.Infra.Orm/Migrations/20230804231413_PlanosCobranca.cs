using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class PlanosCobranca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaGrupAutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoPlano = table.Column<int>(type: "int", nullable: false),
                    PrecoDiaria = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecoKm = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    KmDisponiveis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoCobranca_GrupoAutomoveis",
                        column: x => x.CategoriaGrupAutoId,
                        principalTable: "TBGrupoAutomoveis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_CategoriaGrupAutoId",
                table: "TBPlanoCobranca",
                column: "CategoriaGrupAutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");
        }
    }
}
