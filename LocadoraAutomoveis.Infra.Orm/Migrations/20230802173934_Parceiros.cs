using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Parceiros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBParceiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBParceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cupom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parceiroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cupom_TBParceiros_parceiroId",
                        column: x => x.parceiroId,
                        principalTable: "TBParceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cupom_parceiroId",
                table: "Cupom",
                column: "parceiroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cupom");

            migrationBuilder.DropTable(
                name: "TBParceiros");
        }
    }
}
