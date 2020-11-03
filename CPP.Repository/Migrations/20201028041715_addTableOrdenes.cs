using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class addTableOrdenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdenesId",
                table: "remision",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "estado_orden",
                columns: table => new
                {
                    estado_orden_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado_orden = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_orden", x => x.estado_orden_id);
                });

            migrationBuilder.CreateTable(
                name: "orden",
                columns: table => new
                {
                    orden_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado_orden_id = table.Column<int>(nullable: false),
                    proveedor_id = table.Column<int>(nullable: false),
                    fecha_alta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden", x => x.orden_id);
                    table.ForeignKey(
                        name: "FK_orden_estado_orden_estado_orden_id",
                        column: x => x.estado_orden_id,
                        principalTable: "estado_orden",
                        principalColumn: "estado_orden_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_proveedor_proveedor_id",
                        column: x => x.proveedor_id,
                        principalTable: "proveedor",
                        principalColumn: "proveedor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_remision_OrdenesId",
                table: "remision",
                column: "OrdenesId");

            migrationBuilder.CreateIndex(
                name: "IX_orden_estado_orden_id",
                table: "orden",
                column: "estado_orden_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orden_proveedor_id",
                table: "orden",
                column: "proveedor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_remision_orden_OrdenesId",
                table: "remision",
                column: "OrdenesId",
                principalTable: "orden",
                principalColumn: "orden_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_remision_orden_OrdenesId",
                table: "remision");

            migrationBuilder.DropTable(
                name: "orden");

            migrationBuilder.DropTable(
                name: "estado_orden");

            migrationBuilder.DropIndex(
                name: "IX_remision_OrdenesId",
                table: "remision");

            migrationBuilder.DropColumn(
                name: "OrdenesId",
                table: "remision");
        }
    }
}
