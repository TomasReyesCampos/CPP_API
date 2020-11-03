using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddProveedorContactoReferenceNewVersio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "proveedor_id",
                table: "proveedor_contacto");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "proveedor",
                newName: "proveedor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "proveedor_id",
                table: "proveedor",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "proveedor_id",
                table: "proveedor_contacto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
