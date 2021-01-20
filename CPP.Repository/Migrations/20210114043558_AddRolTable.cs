using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddRolTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_usuario_sucursal_id",
                table: "usuario");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    rol_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(nullable: true),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.rol_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rol_id",
                table: "usuario",
                column: "rol_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_sucursal_id",
                table: "usuario",
                column: "sucursal_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_rol_id",
                table: "usuario",
                column: "rol_id",
                principalTable: "rol",
                principalColumn: "rol_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_rol_id",
                table: "usuario");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropIndex(
                name: "IX_usuario_rol_id",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_sucursal_id",
                table: "usuario");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_sucursal_id",
                table: "usuario",
                column: "sucursal_id");
        }
    }
}
