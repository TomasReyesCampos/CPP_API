using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    usuario_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol_id = table.Column<int>(nullable: false),
                    usuario = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    sucursal_id = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_usuario_sucursal_sucursal_id",
                        column: x => x.sucursal_id,
                        principalTable: "sucursal",
                        principalColumn: "sucursal_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_sucursal_id",
                table: "usuario",
                column: "sucursal_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
