﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CPP.Repository.Migrations
{
    public partial class AddProveedorContactoTableProveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_proveedor_contacto_proveedor_ProveedorId",
                table: "proveedor_contacto");

            migrationBuilder.DropIndex(
                name: "IX_proveedor_contacto_ProveedorId",
                table: "proveedor_contacto");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "proveedor_contacto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "proveedor_contacto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_contacto_ProveedorId",
                table: "proveedor_contacto",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_proveedor_contacto_proveedor_ProveedorId",
                table: "proveedor_contacto",
                column: "ProveedorId",
                principalTable: "proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
