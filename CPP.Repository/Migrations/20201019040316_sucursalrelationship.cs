using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class sucursalrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sucursal",
                newName: "sucursal_id");

            migrationBuilder.AddColumn<int>(
                name: "sucursal_id",
                table: "remision",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_remision_sucursal_id",
                table: "remision",
                column: "sucursal_id");

            migrationBuilder.AddForeignKey(
                name: "FK_remision_sucursal_sucursal_id",
                table: "remision",
                column: "sucursal_id",
                principalTable: "sucursal",
                principalColumn: "sucursal_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_remision_sucursal_sucursal_id",
                table: "remision");

            migrationBuilder.DropIndex(
                name: "IX_remision_sucursal_id",
                table: "remision");

            migrationBuilder.DropColumn(
                name: "sucursal_id",
                table: "remision");

            migrationBuilder.RenameColumn(
                name: "sucursal_id",
                table: "sucursal",
                newName: "Id");
        }
    }
}
