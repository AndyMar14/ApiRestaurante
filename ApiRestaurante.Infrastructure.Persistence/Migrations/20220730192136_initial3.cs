using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestaurante.Infrastructure.Persistence.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMesa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtotal = table.Column<float>(type: "real", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "detalleOrden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrden = table.Column<int>(type: "int", nullable: false),
                    IdPlato = table.Column<int>(type: "int", nullable: false),
                    PlatosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleOrden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleOrden_orden_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "orden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleOrden_platos_PlatosId",
                        column: x => x.PlatosId,
                        principalTable: "platos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalleOrden_IdOrden",
                table: "detalleOrden",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_detalleOrden_PlatosId",
                table: "detalleOrden",
                column: "PlatosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleOrden");

            migrationBuilder.DropTable(
                name: "orden");
        }
    }
}
