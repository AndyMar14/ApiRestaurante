using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestaurante.Infrastructure.Persistence.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DetallePlatos_IdIngrediente",
                table: "DetallePlatos",
                column: "IdIngrediente");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePlatos_ingredientes_IdIngrediente",
                table: "DetallePlatos",
                column: "IdIngrediente",
                principalTable: "ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePlatos_ingredientes_IdIngrediente",
                table: "DetallePlatos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePlatos_IdIngrediente",
                table: "DetallePlatos");
        }
    }
}
