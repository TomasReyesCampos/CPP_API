using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class addColumnasPagoOrden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "banco",
                table: "orden",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "comentarios",
                table: "orden",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numero_cheque",
                table: "orden",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numero_transferencia",
                table: "orden",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "persona_recibe",
                table: "orden",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "banco",
                table: "orden");

            migrationBuilder.DropColumn(
                name: "comentarios",
                table: "orden");

            migrationBuilder.DropColumn(
                name: "numero_cheque",
                table: "orden");

            migrationBuilder.DropColumn(
                name: "numero_transferencia",
                table: "orden");

            migrationBuilder.DropColumn(
                name: "persona_recibe",
                table: "orden");
        }
    }
}
