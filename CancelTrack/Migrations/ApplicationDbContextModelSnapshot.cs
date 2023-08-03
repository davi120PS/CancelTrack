﻿// <auto-generated />
using System;
using CancelTrack.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CancelTrack.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CancelTrack.Entities.Cliente", b =>
                {
                    b.Property<int>("PKCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("PKCliente");

                    b.ToTable("Cliente");

                    b.HasData(
                        new
                        {
                            PKCliente = 1,
                            Apellido = "Apellido",
                            Correo = "correo1@gmail.com",
                            Direccion = "Direccion 1",
                            Nombre = "Cliente 1",
                            Telefono = 2524
                        },
                        new
                        {
                            PKCliente = 2,
                            Apellido = "Apellido",
                            Correo = "correo1@gmail.com",
                            Direccion = "Direccion 2",
                            Nombre = "Cliente 2",
                            Telefono = 3452
                        });
                });

            modelBuilder.Entity("CancelTrack.Entities.Empleado", b =>
                {
                    b.Property<int>("PKEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int?>("FKPuesto")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("PKEmpleado");

                    b.HasIndex("FKPuesto");

                    b.ToTable("Empleado");

                    b.HasData(
                        new
                        {
                            PKEmpleado = 1,
                            Apellido = "Peña",
                            Contraseña = "123",
                            Correo = "davi@gmail.com",
                            Estado = 1,
                            FKPuesto = 1,
                            Matricula = "davi",
                            Nombre = "David",
                            Telefono = 1234
                        },
                        new
                        {
                            PKEmpleado = 2,
                            Apellido = "Cortez",
                            Contraseña = "123",
                            Correo = "diego@gmail.com",
                            Estado = 1,
                            FKPuesto = 2,
                            Matricula = "diego",
                            Nombre = "Diego",
                            Telefono = 1234
                        });
                });

            modelBuilder.Entity("CancelTrack.Entities.Producto", b =>
                {
                    b.Property<int>("PKProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadInventario")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FKProveedor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PrecioCompra")
                        .HasColumnType("int");

                    b.Property<int>("PrecioVenta")
                        .HasColumnType("int");

                    b.HasKey("PKProducto");

                    b.HasIndex("FKProveedor");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            PKProducto = 1,
                            CantidadInventario = 200,
                            Descripcion = "Descripcion 1",
                            FKProveedor = 1,
                            Nombre = "Producto 1",
                            PrecioCompra = 1500,
                            PrecioVenta = 2000
                        },
                        new
                        {
                            PKProducto = 2,
                            CantidadInventario = 200,
                            Descripcion = "Descripcion 2",
                            FKProveedor = 1,
                            Nombre = "Producto 2",
                            PrecioCompra = 2000,
                            PrecioVenta = 2500
                        },
                        new
                        {
                            PKProducto = 3,
                            CantidadInventario = 200,
                            Descripcion = "Descripcion 3",
                            FKProveedor = 2,
                            Nombre = "Producto 3",
                            PrecioCompra = 1800,
                            PrecioVenta = 2200
                        });
                });

            modelBuilder.Entity("CancelTrack.Entities.Proveedor", b =>
                {
                    b.Property<int>("PKProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("PKProveedor");

                    b.ToTable("Proveedor");

                    b.HasData(
                        new
                        {
                            PKProveedor = 1,
                            Correo = "correo1@gmail.com",
                            Direccion = "Direccion 1",
                            Nombre = "Proveedor 1",
                            Telefono = 2524
                        },
                        new
                        {
                            PKProveedor = 2,
                            Correo = "correo1@gmail.com",
                            Direccion = "Direccion 2",
                            Nombre = "Proveedor 2",
                            Telefono = 2524
                        });
                });

            modelBuilder.Entity("CancelTrack.Entities.Puesto", b =>
                {
                    b.Property<int>("PKPuesto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PKPuesto");

                    b.ToTable("Puesto");

                    b.HasData(
                        new
                        {
                            PKPuesto = 1,
                            Nombre = "Admin"
                        },
                        new
                        {
                            PKPuesto = 2,
                            Nombre = "Vendedor"
                        });
                });

            modelBuilder.Entity("CancelTrack.Entities.Venta", b =>
                {
                    b.Property<int>("PKVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FKCliente")
                        .HasColumnType("int");

                    b.Property<int>("FKEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("PKVenta");

                    b.HasIndex("FKCliente");

                    b.HasIndex("FKEmpleado");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("CancelTrack.Entities.VentaProducto", b =>
                {
                    b.Property<int>("PKVentaProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("FKProducto")
                        .HasColumnType("int");

                    b.Property<int>("FKVentas")
                        .HasColumnType("int");

                    b.HasKey("PKVentaProducto");

                    b.HasIndex("FKProducto");

                    b.HasIndex("FKVentas");

                    b.ToTable("VentaProducto");
                });

            modelBuilder.Entity("ProductoVenta", b =>
                {
                    b.Property<int>("ProductosPKProducto")
                        .HasColumnType("int");

                    b.Property<int>("VentasPKVenta")
                        .HasColumnType("int");

                    b.HasKey("ProductosPKProducto", "VentasPKVenta");

                    b.HasIndex("VentasPKVenta");

                    b.ToTable("ProductoVenta");
                });

            modelBuilder.Entity("CancelTrack.Entities.Empleado", b =>
                {
                    b.HasOne("CancelTrack.Entities.Puesto", "Puestos")
                        .WithMany()
                        .HasForeignKey("FKPuesto");

                    b.Navigation("Puestos");
                });

            modelBuilder.Entity("CancelTrack.Entities.Producto", b =>
                {
                    b.HasOne("CancelTrack.Entities.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("FKProveedor");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("CancelTrack.Entities.Venta", b =>
                {
                    b.HasOne("CancelTrack.Entities.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("FKCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CancelTrack.Entities.Empleado", "Empleados")
                        .WithMany()
                        .HasForeignKey("FKEmpleado")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("CancelTrack.Entities.VentaProducto", b =>
                {
                    b.HasOne("CancelTrack.Entities.Producto", "Productos")
                        .WithMany("VentaProductos")
                        .HasForeignKey("FKProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CancelTrack.Entities.Venta", "Ventas")
                        .WithMany("VentaProductos")
                        .HasForeignKey("FKVentas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Productos");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("ProductoVenta", b =>
                {
                    b.HasOne("CancelTrack.Entities.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductosPKProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CancelTrack.Entities.Venta", null)
                        .WithMany()
                        .HasForeignKey("VentasPKVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CancelTrack.Entities.Producto", b =>
                {
                    b.Navigation("VentaProductos");
                });

            modelBuilder.Entity("CancelTrack.Entities.Venta", b =>
                {
                    b.Navigation("VentaProductos");
                });
#pragma warning restore 612, 618
        }
    }
}
