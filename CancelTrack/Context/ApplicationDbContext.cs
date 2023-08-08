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
            options.UseMySQL("server=localhost; database=CancelTrack2; user=root; password=");
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
        // Cuando se elimina una venta, tambien se eliminan las ventas del producto relacionadas
            modelBuilder.Entity<Venta>()
                .HasMany(v => v.VentaProductos)
                .WithOne(vp => vp.Ventas)
                .HasForeignKey(vp => vp.FKVentas)
                .OnDelete(DeleteBehavior.Restrict); // ON DELETE CASCADE
                //.OnUpdate(DeleteBehavior.Cascade);
            // Cuando se elimina una cliente, tambien se elimina solo una venta relacionada
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Clientes)
                .WithMany()
                .HasForeignKey(v => v.FKCliente)
                .OnDelete(DeleteBehavior.Restrict);
        // Cuando se elimina un empleado, tambien se elimina solo una venta relacionada
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Empleados)
                .WithMany()
                .HasForeignKey(v => v.FKEmpleado)
                .OnDelete(DeleteBehavior.Restrict);
            // Cuando se elimina una ventaproducto, tambien se eliminan las ventas relacionadas
            /*modelBuilder.Entity<VentaProducto>()
                .HasOne(vp => vp.Ventas)
                .WithMany()//(v => v.VentaProductos)
                .HasForeignKey(vp => vp.FKVentas)
                .OnDelete(DeleteBehavior.Cascade); // ON DELETE CASCADE*/
              //.HasPrincipalKey(v => v.PKVenta) // Clave principal de Venta
              //.IsRequired

            // Insert para la tabla de Usuarios
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    PKEmpleado = 1,
                    Nombre = "David",
                    Apellido = "Peña",
                    Matricula = "davi120",
                    Contraseña = "12345",
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
                    Matricula = "dieguitocraft",
                    Contraseña = "12345",
                    FKPuesto = 2,
                    Telefono = 1234,
                    Correo = "diego@gmail.com",
                    Estado = 1
                },
                new Empleado
                {
                    PKEmpleado = 3,
                    Nombre = "Jorge",
                    Apellido = "De Los Santos",
                    Matricula = "simulador",
                    Contraseña = "12345",
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
                    Nombre = "Johny",
                    Apellido = "Walker",
                    Direccion = "2453 Goldcliff Circle",
                    Telefono = 252464,
                    Correo = "correo1@gmail.com"
                },
                new Cliente
                {
                    PKCliente = 2,
                    Nombre = "Carolina",
                    Apellido = "Herrera",
                    Direccion = "1235 Filbert Street",
                    Telefono = 345642,
                    Correo = "correo1@gmail.com"
                }
            );
            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor
                {
                    PKProveedor = 1,
                    Nombre = "Juan Perez",
                    Direccion = "4090 Olen Thomas Drive",
                    Telefono = 252534,
                    Correo = "jp21@gmail.com"
                },
                new Proveedor
                {
                    PKProveedor = 2,
                    Nombre = "Ronnie Morales",
                    Direccion = "3224 Calico Drive",
                    Telefono = 633524,
                    Correo = "rm41@gmail.com"
                }
            );
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    PKProducto = 1,
                    Nombre = "Perfil de aluminio Serie 8000",
                    Descripcion = "Aluminio color negro",
                    FKProveedor = 1,
                    PrecioVenta = 3500,
                    PrecioCompra = 2500,
                    CantidadInventario = 200
                },
                new Producto
                {
                    PKProducto = 2,
                    Nombre = "Perfil de aluminio Serie 5000",
                    Descripcion = "Aluminio color natural",
                    FKProveedor = 1,
                    PrecioVenta = 2500,
                    PrecioCompra = 2000,
                    CantidadInventario = 200
                },
                new Producto
                {
                    PKProducto = 3,
                    Nombre = "Perfil de aluminio Serie 3000",
                    Descripcion = "Aluminio color negro",
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
