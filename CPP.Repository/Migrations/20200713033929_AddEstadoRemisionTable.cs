using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddEstadoRemisionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_formaPago",
                table: "formaPago");

            migrationBuilder.RenameTable(
                name: "formaPago",
                newName: "forma_pago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_forma_pago",
                table: "forma_pago",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "estado_remision",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado_remision = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_remision", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estado_remision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_forma_pago",
                table: "forma_pago");

            migrationBuilder.RenameTable(
                name: "forma_pago",
                newName: "formaPago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_formaPago",
                table: "formaPago",
                column: "Id");
        }
    }
}
