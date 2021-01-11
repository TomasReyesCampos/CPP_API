using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class newfieldstoOrdenesSucursal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "direccion",
                table: "sucursal",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefono",
                table: "sucursal",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "numero_remision",
                table: "remision",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "usuario_autoriza",
                table: "orden",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "direccion",
                table: "sucursal");

            migrationBuilder.DropColumn(
                name: "telefono",
                table: "sucursal");

            migrationBuilder.DropColumn(
                name: "numero_remision",
                table: "remision");

            migrationBuilder.DropColumn(
                name: "usuario_autoriza",
                table: "orden");
        }
    }
}
