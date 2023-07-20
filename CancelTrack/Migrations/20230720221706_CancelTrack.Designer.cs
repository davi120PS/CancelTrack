﻿// <auto-generated />
using System;
using CancelTrack.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CancelTrack.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230720221706_CancelTrack")]
    partial class CancelTrack
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("FKPuesto")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PuestosPKPuesto")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("PKEmpleado");

                    b.HasIndex("PuestosPKPuesto");

                    b.ToTable("Empleado");
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

                    b.Property<int>("FKProveedor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("PKProducto");

                    b.HasIndex("FKProveedor");

                    b.ToTable("Producto");
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

                    b.Property<int>("PrecioProveedor")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("PKProveedor");

                    b.ToTable("Proveedor");
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
                });

            modelBuilder.Entity("CancelTrack.Entities.Venta", b =>
                {
                    b.Property<int>("PKVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("EmployeePKEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("FKCliente")
                        .HasColumnType("int");

                    b.Property<int>("FKEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("PKVenta");

                    b.HasIndex("EmployeePKEmpleado");

                    b.HasIndex("FKCliente");

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

                    b.Property<int>("FKVenta")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("PKVentaProducto");

                    b.HasIndex("FKProducto");

                    b.HasIndex("FKVenta");

                    b.ToTable("VentaProducto");
                });

            modelBuilder.Entity("CancelTrack.Entities.Empleado", b =>
                {
                    b.HasOne("CancelTrack.Entities.Puesto", "Puestos")
                        .WithMany()
                        .HasForeignKey("PuestosPKPuesto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Puestos");
                });

            modelBuilder.Entity("CancelTrack.Entities.Producto", b =>
                {
                    b.HasOne("CancelTrack.Entities.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("FKProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("CancelTrack.Entities.Venta", b =>
                {
                    b.HasOne("CancelTrack.Entities.Empleado", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeePKEmpleado");

                    b.HasOne("CancelTrack.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("FKCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CancelTrack.Entities.VentaProducto", b =>
                {
                    b.HasOne("CancelTrack.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("FKProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CancelTrack.Entities.Venta", "Venta")
                        .WithMany()
                        .HasForeignKey("FKVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Venta");
                });
#pragma warning restore 612, 618
        }
    }
}
