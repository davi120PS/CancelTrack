using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CancelTrack.Migrations
{
    /// <inheritdoc />
    public partial class CancelTrack2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    PKCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Apellido = table.Column<string>(type: "longtext", nullable: false),
                    Direccion = table.Column<string>(type: "longtext", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.PKCliente);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    PKProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Direccion = table.Column<string>(type: "longtext", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.PKProveedor);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    PKPuesto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.PKPuesto);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    PKProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    FKProveedor = table.Column<int>(type: "int", nullable: true),
                    PrecioVenta = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<int>(type: "int", nullable: false),
                    CantidadInventario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.PKProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor_FKProveedor",
                        column: x => x.FKProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "PKProveedor");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    PKEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Apellido = table.Column<string>(type: "longtext", nullable: false),
                    Matricula = table.Column<string>(type: "longtext", nullable: false),
                    Contraseña = table.Column<string>(type: "longtext", nullable: false),
                    FKPuesto = table.Column<int>(type: "int", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.PKEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Puesto_FKPuesto",
                        column: x => x.FKPuesto,
                        principalTable: "Puesto",
                        principalColumn: "PKPuesto");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    PKVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FKCliente = table.Column<int>(type: "int", nullable: false),
                    FKEmpleado = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.PKVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_FKCliente",
                        column: x => x.FKCliente,
                        principalTable: "Cliente",
                        principalColumn: "PKCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venta_Empleado_FKEmpleado",
                        column: x => x.FKEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "PKEmpleado",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductoVenta",
                columns: table => new
                {
                    ProductosPKProducto = table.Column<int>(type: "int", nullable: false),
                    VentasPKVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoVenta", x => new { x.ProductosPKProducto, x.VentasPKVenta });
                    table.ForeignKey(
                        name: "FK_ProductoVenta_Producto_ProductosPKProducto",
                        column: x => x.ProductosPKProducto,
                        principalTable: "Producto",
                        principalColumn: "PKProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoVenta_Venta_VentasPKVenta",
                        column: x => x.VentasPKVenta,
                        principalTable: "Venta",
                        principalColumn: "PKVenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VentaProducto",
                columns: table => new
                {
                    PKVentaProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FKVentas = table.Column<int>(type: "int", nullable: false),
                    FKProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaProducto", x => x.PKVentaProducto);
                    table.ForeignKey(
                        name: "FK_VentaProducto_Producto_FKProducto",
                        column: x => x.FKProducto,
                        principalTable: "Producto",
                        principalColumn: "PKProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaProducto_Venta_FKVentas",
                        column: x => x.FKVentas,
                        principalTable: "Venta",
                        principalColumn: "PKVenta",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "PKCliente", "Apellido", "Correo", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Apellido", "correo1@gmail.com", "Direccion 1", "Cliente 1", 2524 },
                    { 2, "Apellido", "correo1@gmail.com", "Direccion 2", "Cliente 2", 3452 }
                });

            migrationBuilder.InsertData(
                table: "Proveedor",
                columns: new[] { "PKProveedor", "Correo", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "correo1@gmail.com", "Direccion 1", "Proveedor 1", 2524 },
                    { 2, "correo1@gmail.com", "Direccion 2", "Proveedor 2", 2524 }
                });

            migrationBuilder.InsertData(
                table: "Puesto",
                columns: new[] { "PKPuesto", "Nombre" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Vendedor" }
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "PKEmpleado", "Apellido", "Contraseña", "Correo", "Estado", "FKPuesto", "Matricula", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Peña", "123", "davi@gmail.com", 1, 1, "davi", "David", 1234 },
                    { 2, "Cortez", "123", "diego@gmail.com", 1, 2, "diego", "Diego", 1234 }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "PKProducto", "CantidadInventario", "Descripcion", "FKProveedor", "Nombre", "PrecioCompra", "PrecioVenta" },
                values: new object[,]
                {
                    { 1, 200, "Descripcion 1", 1, "Producto 1", 1500, 2000 },
                    { 2, 200, "Descripcion 2", 1, "Producto 2", 2000, 2500 },
                    { 3, 200, "Descripcion 3", 2, "Producto 3", 1800, 2200 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_FKPuesto",
                table: "Empleado",
                column: "FKPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_FKProveedor",
                table: "Producto",
                column: "FKProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVenta_VentasPKVenta",
                table: "ProductoVenta",
                column: "VentasPKVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_FKCliente",
                table: "Venta",
                column: "FKCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_FKEmpleado",
                table: "Venta",
                column: "FKEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto_FKProducto",
                table: "VentaProducto",
                column: "FKProducto");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto_FKVentas",
                table: "VentaProducto",
                column: "FKVentas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoVenta");

            migrationBuilder.DropTable(
                name: "VentaProducto");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Puesto");
        }
    }
}
