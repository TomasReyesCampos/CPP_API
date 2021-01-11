using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class addCamposAdicionesSucurcalProveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "correo",
                table: "proveedor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "correo",
                table: "proveedor");
        }
    }
}
