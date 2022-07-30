using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestaurante.Infrastructure.Persistence.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredientes_platos_PlatosId",
                table: "ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_ingredientes_PlatosId",
                table: "ingredientes");

            migrationBuilder.DropColumn(
                name: "PlatosId",
                table: "ingredientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlatosId",
                table: "ingredientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ingredientes_PlatosId",
                table: "ingredientes",
                column: "PlatosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ingredientes_platos_PlatosId",
                table: "ingredientes",
                column: "PlatosId",
                principalTable: "platos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
