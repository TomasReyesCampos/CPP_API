using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddRemisionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "remision",
                columns: table => new
                {
                    remision_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proveedor_id = table.Column<int>(nullable: false),
                    estado_remision_id = table.Column<int>(nullable: false),
                    cantidad = table.Column<float>(nullable: false),
                    fecha_remision = table.Column<DateTime>(nullable: false),
                    fecha_pago = table.Column<DateTime>(nullable: false),
                    comentarios = table.Column<string>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_remision", x => x.remision_id);
                    table.ForeignKey(
                        name: "FK_remision_estado_remision_estado_remision_id",
                        column: x => x.estado_remision_id,
                        principalTable: "estado_remision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_remision_estado_remision_id",
                table: "remision",
                column: "estado_remision_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "remision");
        }
    }
}
