using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Compras.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    productoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombreProducto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    stock = table.Column<int>(type: "int", maxLength: 250, precision: 12, nullable: false, defaultValue: 0),
                    precio = table.Column<decimal>(type: "decimal(14,2)", maxLength: 250, precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.productoId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    proveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombreCompleto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ubicacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.proveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    compraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    total = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    proveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.compraId);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedor_proveedorId",
                        column: x => x.proveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "proveedorId");
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompra",
                columns: table => new
                {
                    detalleCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    compraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompra", x => x.detalleCompraId);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Compras_compraId",
                        column: x => x.compraId,
                        principalTable: "Compras",
                        principalColumn: "compraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Producto_productoId",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "productoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_proveedorId",
                table: "Compras",
                column: "proveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_compraId",
                table: "DetalleCompra",
                column: "compraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_productoId",
                table: "DetalleCompra",
                column: "productoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCompra");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
