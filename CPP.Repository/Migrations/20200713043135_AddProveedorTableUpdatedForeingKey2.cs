using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddProveedorTableUpdatedForeingKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "proveedor_id",
                table: "tipo_proveedor");

            migrationBuilder.DropColumn(
                name: "proveedor_id",
                table: "forma_pago");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "proveedor_id",
                table: "tipo_proveedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "proveedor_id",
                table: "forma_pago",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
