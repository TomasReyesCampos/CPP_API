using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddProveedorTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormaPago_Proveedor_proveedor_id",
                table: "FormaPago");

            migrationBuilder.DropForeignKey(
                name: "FK_tipo_proveedor_Proveedor_proveedor_id",
                table: "tipo_proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPago",
                table: "FormaPago");

            migrationBuilder.RenameTable(
                name: "Proveedor",
                newName: "proveedor");

            migrationBuilder.RenameTable(
                name: "FormaPago",
                newName: "forma_pago");

            migrationBuilder.RenameIndex(
                name: "IX_FormaPago_proveedor_id",
                table: "forma_pago",
                newName: "IX_forma_pago_proveedor_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_proveedor",
                table: "proveedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_forma_pago",
                table: "forma_pago",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_forma_pago_proveedor_proveedor_id",
                table: "forma_pago");

            migrationBuilder.DropForeignKey(
                name: "FK_tipo_proveedor_proveedor_proveedor_id",
                table: "tipo_proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proveedor",
                table: "proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_forma_pago",
                table: "forma_pago");

            migrationBuilder.RenameTable(
                name: "proveedor",
                newName: "Proveedor");

            migrationBuilder.RenameTable(
                name: "forma_pago",
                newName: "FormaPago");

            migrationBuilder.RenameIndex(
                name: "IX_forma_pago_proveedor_id",
                table: "FormaPago",
                newName: "IX_FormaPago_proveedor_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPago",
                table: "FormaPago",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormaPago_Proveedor_proveedor_id",
                table: "FormaPago",
                column: "proveedor_id",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tipo_proveedor_Proveedor_proveedor_id",
                table: "tipo_proveedor",
                column: "proveedor_id",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
