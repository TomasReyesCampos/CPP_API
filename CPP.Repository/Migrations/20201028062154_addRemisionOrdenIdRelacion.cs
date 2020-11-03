using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class addRemisionOrdenIdRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_remision_orden_OrdenesId",
                table: "remision");

            migrationBuilder.DropIndex(
                name: "IX_remision_OrdenesId",
                table: "remision");

            migrationBuilder.DropColumn(
                name: "OrdenesId",
                table: "remision");

            migrationBuilder.AddColumn<int>(
                name: "ordenId",
                table: "remision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orden_id",
                table: "remision",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_remision_ordenId",
                table: "remision",
                column: "ordenId");

            migrationBuilder.AddForeignKey(
                name: "FK_remision_orden_ordenId",
                table: "remision",
                column: "ordenId",
                principalTable: "orden",
                principalColumn: "orden_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_remision_orden_ordenId",
                table: "remision");

            migrationBuilder.DropIndex(
                name: "IX_remision_ordenId",
                table: "remision");

            migrationBuilder.DropColumn(
                name: "ordenId",
                table: "remision");

            migrationBuilder.DropColumn(
                name: "orden_id",
                table: "remision");

            migrationBuilder.AddColumn<int>(
                name: "OrdenesId",
                table: "remision",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_remision_OrdenesId",
                table: "remision",
                column: "OrdenesId");

            migrationBuilder.AddForeignKey(
                name: "FK_remision_orden_OrdenesId",
                table: "remision",
                column: "OrdenesId",
                principalTable: "orden",
                principalColumn: "orden_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
