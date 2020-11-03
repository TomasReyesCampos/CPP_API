using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddProveedorContactoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proveedor_contacto",
                columns: table => new
                {
                    proveedor_contacto_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proveedor_id = table.Column<int>(nullable: false),
                    tipo_contacto_id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(nullable: false),
                    correo = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    activo = table.Column<string>(nullable: true),
                    ProveedorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor_contacto", x => x.proveedor_contacto_id);
                    table.ForeignKey(
                        name: "FK_proveedor_contacto_proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proveedor_contacto_tipo_contacto_tipo_contacto_id",
                        column: x => x.tipo_contacto_id,
                        principalTable: "tipo_contacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_contacto_ProveedorId",
                table: "proveedor_contacto",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_contacto_tipo_contacto_id",
                table: "proveedor_contacto",
                column: "tipo_contacto_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "proveedor_contacto");
        }
    }
}
