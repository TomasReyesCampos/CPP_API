using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class changeformapagoidcolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "proveedor_id",
                table: "forma_pago",
                newName: "forma_pago_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "forma_pago_id",
                table: "forma_pago",
                newName: "proveedor_id");
        }
    }
}
