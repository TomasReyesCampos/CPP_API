using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class removeestadoOrdenUniqueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.DropIndex(
            name: "IX_orden_estado_orden_id",
            table: "orden");
         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
               name: "IX_orden_estado_orden_id",
               table: "orden",
               column: "estado_orden_id");
        }
    }
}
