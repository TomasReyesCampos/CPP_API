using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddRemisionTableProveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_remision_proveedor_id",
                table: "remision",
                column: "proveedor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_remision_proveedor_proveedor_id",
                table: "remision",
                column: "proveedor_id",
                principalTable: "proveedor",
                principalColumn: "proveedor_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_remision_proveedor_proveedor_id",
                table: "remision");

            migrationBuilder.DropIndex(
                name: "IX_remision_proveedor_id",
                table: "remision");
        }
    }
}
