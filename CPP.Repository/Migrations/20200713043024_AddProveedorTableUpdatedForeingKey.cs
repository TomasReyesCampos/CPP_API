using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddProveedorTableUpdatedForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_forma_pago_proveedor_proveedor_id",
                table: "forma_pago");

            migrationBuilder.DropForeignKey(
                name: "FK_tipo_proveedor_proveedor_proveedor_id",
                table: "tipo_proveedor");

            migrationBuilder.DropIndex(
                name: "IX_tipo_proveedor_proveedor_id",
                table: "tipo_proveedor");

            migrationBuilder.DropIndex(
                name: "IX_forma_pago_proveedor_id",
                table: "forma_pago");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_forma_pago_id",
                table: "proveedor",
                column: "forma_pago_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_tipo_proveedor_id",
                table: "proveedor",
                column: "tipo_proveedor_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_proveedor_forma_pago_forma_pago_id",
                table: "proveedor",
                column: "forma_pago_id",
                principalTable: "forma_pago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_proveedor_tipo_proveedor_tipo_proveedor_id",
                table: "proveedor",
                column: "tipo_proveedor_id",
                principalTable: "tipo_proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_proveedor_forma_pago_forma_pago_id",
                table: "proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_proveedor_tipo_proveedor_tipo_proveedor_id",
                table: "proveedor");

            migrationBuilder.DropIndex(
                name: "IX_proveedor_forma_pago_id",
                table: "proveedor");

            migrationBuilder.DropIndex(
                name: "IX_proveedor_tipo_proveedor_id",
                table: "proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_proveedor_proveedor_id",
                table: "tipo_proveedor",
                column: "proveedor_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_forma_pago_proveedor_id",
                table: "forma_pago",
                column: "proveedor_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_forma_pago_proveedor_proveedor_id",
                table: "forma_pago",
                column: "proveedor_id",
                principalTable: "proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tipo_proveedor_proveedor_proveedor_id",
                table: "tipo_proveedor",
                column: "proveedor_id",
                principalTable: "proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
