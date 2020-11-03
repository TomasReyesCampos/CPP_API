using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddProveedorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_forma_pago",
                table: "forma_pago");

            migrationBuilder.RenameTable(
                name: "forma_pago",
                newName: "FormaPago");

            migrationBuilder.AddColumn<int>(
                name: "proveedor_id",
                table: "tipo_proveedor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "proveedor_id",
                table: "FormaPago",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPago",
                table: "FormaPago",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 60, nullable: false),
                    direccion = table.Column<string>(maxLength: 500, nullable: false),
                    rfc = table.Column<string>(maxLength: 15, nullable: false),
                    codigo_postal = table.Column<string>(maxLength: 6, nullable: false),
                    telefono = table.Column<string>(maxLength: 25, nullable: false),
                    dias_credito = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false),
                    forma_pago_id = table.Column<int>(nullable: false),
                    tipo_proveedor_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tipo_proveedor_proveedor_id",
                table: "tipo_proveedor",
                column: "proveedor_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormaPago_proveedor_id",
                table: "FormaPago",
                column: "proveedor_id",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormaPago_Proveedor_proveedor_id",
                table: "FormaPago");

            migrationBuilder.DropForeignKey(
                name: "FK_tipo_proveedor_Proveedor_proveedor_id",
                table: "tipo_proveedor");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_tipo_proveedor_proveedor_id",
                table: "tipo_proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPago",
                table: "FormaPago");

            migrationBuilder.DropIndex(
                name: "IX_FormaPago_proveedor_id",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "proveedor_id",
                table: "tipo_proveedor");

            migrationBuilder.DropColumn(
                name: "proveedor_id",
                table: "FormaPago");

            migrationBuilder.RenameTable(
                name: "FormaPago",
                newName: "forma_pago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_forma_pago",
                table: "forma_pago",
                column: "Id");
        }
    }
}
