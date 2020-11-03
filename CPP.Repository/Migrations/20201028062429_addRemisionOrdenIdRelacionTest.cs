using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class addRemisionOrdenIdRelacionTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_remision_orden_id",
                table: "remision",
                column: "orden_id");

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_remision_orden_orden_id",
                table: "remision");

            migrationBuilder.DropIndex(
                name: "IX_remision_orden_id",
                table: "remision");

            migrationBuilder.AddColumn<int>(
                name: "ordenId",
                table: "remision",
                type: "int",
                nullable: true);

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
    }
}
