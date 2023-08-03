using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CancelTrack.Entities;

namespace CancelTrack.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=localhost; database=CancelTrack; user=root; password=");
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<VentaProducto> VentaProducto { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venta>()
                .HasMany(v => v.VentaProductos)
                .WithOne(vp => vp.Ventas)
                .HasForeignKey(vp => vp.FKVentas)
                .OnDelete(DeleteBehavior.Cascade); // ON DELETE CASCADE

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Clientes)
                .WithMany()
                .HasForeignKey(v => v.FKCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Empleados)
                .WithMany()
                .HasForeignKey(v => v.FKEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VentaProducto>()
                .HasOne(vp => vp.Ventas)
                .WithMany(v => v.VentaProductos)
                .HasForeignKey(vp => vp.FKVentas)
                .OnDelete(DeleteBehavior.Cascade) // ON DELETE CASCADE
                .HasPrincipalKey(v => v.PKVenta) // Clave principal de Venta
                .IsRequired();

            // Insert para la tabla de Usuarios
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    PKEmpleado = 1,
                    Nombre = "David",
                    Apellido = "Peña",
                    Matricula = "davi",
                    Contraseña = "123",
                    FKPuesto = 1,
                    Telefono = 1234,
                    Correo = "davi@gmail.com",
                    Estado = 1
                },
                new Empleado
                {
                    PKEmpleado = 2,
                    Nombre = "Diego",
                    Apellido = "Cortez",
                    Matricula = "diego",
                    Contraseña = "123",
                    FKPuesto = 2,
                    Telefono = 1234,
                    Correo = "diego@gmail.com",
                    Estado = 1
                }
            );
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    PKCliente = 1,
                    Nombre = "Cliente 1",
                    Apellido = "Apellido",
                    Direccion = "Direccion 1",
                    Telefono = 2524,
                    Correo = "correo1@gmail.com"
                },
                new Cliente
                {
                    PKCliente = 2,
                    Nombre = "Cliente 2",
                    Apellido = "Apellido",
                    Direccion = "Direccion 2",
                    Telefono = 3452,
                    Correo = "correo1@gmail.com"
                }
            );
            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor
                {
                    PKProveedor = 1,
                    Nombre = "Proveedor 1",
                    Direccion = "Direccion 1",
                    Telefono = 2524,
                    Correo = "correo1@gmail.com"
                },
                new Proveedor
                {
                    PKProveedor = 2,
                    Nombre = "Proveedor 2",
                    Direccion = "Direccion 2",
                    Telefono = 2524,
                    Correo = "correo1@gmail.com"
                }
            );
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    PKProducto = 1,
                    Nombre = "Producto 1",
                    Descripcion = "Descripcion 1",
                    FKProveedor = 1,
                    PrecioVenta = 2000,
                    PrecioCompra = 1500,
                    CantidadInventario = 200
                },
                new Producto
                {
                    PKProducto = 2,
                    Nombre = "Producto 2",
                    Descripcion = "Descripcion 2",
                    FKProveedor = 1,
                    PrecioVenta = 2500,
                    PrecioCompra = 2000,
                    CantidadInventario = 200
                },
                new Producto
                {
                    PKProducto = 3,
                    Nombre = "Producto 3",
                    Descripcion = "Descripcion 3",
                    FKProveedor = 2,
                    PrecioVenta = 2200,
                    PrecioCompra = 1800,
                    CantidadInventario = 200
                }
            );
            /*modelBuilder.Entity<VentaProducto>().HasData(
                new VentaProducto
                {
                    PKVentaProducto = 1,
                    FKVentas = 1,
                    FKProducto = 1,
                    Cantidad = 1
                },
                new VentaProducto
                {
                    PKVentaProducto = 2,
                    FKVentas = 2,
                    FKProducto = 2,
                    Cantidad = 3
                }
            );
            modelBuilder.Entity<Venta>().HasData(
                new Venta
                {
                    PKVenta = 1,
                    FKCliente = 1,
                    FKEmpleado = 2,
                    Total = 2000
                },
                new Venta
                {
                    PKVenta = 2,
                    FKCliente = 1,
                    FKEmpleado = 2,
                    Total = 7500
                }
            );*/
            modelBuilder.Entity<Puesto>().HasData(
                new Puesto
                {
                    PKPuesto = 1,
                    Nombre = "Admin"
                },
                new Puesto
                {
                    PKPuesto = 2,
                    Nombre = "Vendedor"
                }
            );
        }
    }
}
