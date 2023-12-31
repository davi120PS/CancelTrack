﻿using CancelTrack.Context;
using CancelTrack.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CancelTrack.Services
{
    public class VentaServices
    {
        ProductoServices productoServices = new ProductoServices();
        #region ADD
        public void Add(Venta request) // Modificamos el retorno para devolver la PKVenta generada
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Venta res = new Venta();
                        res.FKCliente = request.FKCliente;
                        res.FKEmpleado = request.FKEmpleado;
                        res.Total = request.Total;
                        _context.Venta.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        #endregion
        #region UPDATE
        public void Update(Venta request)//recibe todos los datos del empleado
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Venta update = _context.Venta.Find(request.PKVenta);
                    update.FKCliente = request.FKCliente;
                    update.FKEmpleado = request.FKEmpleado;
                    update.Total = request.Total;

                    _context.Venta.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public void UpdateTotal(Venta request)//recibe todos los datos del empleado
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Venta update = _context.Venta.Find(request.PKVenta);
                    update.Total = request.Total;

                    _context.Venta.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public void UpdateInventoryAfterDeletion(int ventaId, List<VentaProducto> productos)
        {       // Solo actualiza el inventario cuando eliminas desde la Tabla Venta
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Venta venta = _context.Venta.Find(ventaId);

                    if (venta != null && productos != null && productos.Any())
                    {
                        foreach (var producto in productos)
                        {
                            productoServices.UpdateCantidadInventario(producto.FKProducto, -producto.Cantidad);
                        }
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Inventario: " + ex.Message);
            }
        }
        public void UpdateTotalAndInventoryAfterDeletion(int ventaId, List<VentaProducto> productos)
        {       // Actualiza el Total e Inventario cuando eliminas desde la Tabla VentaProducto
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Venta venta = _context.Venta.Find(ventaId);

                    if (venta != null && productos != null && productos.Any())
                    {
                        int totalReduction = 0;
                        foreach (var producto in productos)
                        {
                            totalReduction += producto.Productos.PrecioVenta * producto.Cantidad;
                            productoServices.UpdateCantidadInventario(producto.FKProducto, -producto.Cantidad);
                        }

                        // Actualizar el Total de la venta
                        venta.Total -= totalReduction;
                        _context.Venta.Update(venta);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Total y el Inventario: " + ex.Message);
            }
        }
        #endregion
        #region DELETE
        public void Delete(int ventaId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Venta venta = _context.Venta.Include(v => v.VentaProductos).FirstOrDefault(v => v.PKVenta == ventaId);
                    if (venta != null)
                    {
                       
                        _context.VentaProducto.RemoveRange(venta.VentaProductos);

                        _context.Remove(venta);
                        _context.SaveChanges();
                    }
                    else
                        MessageBox.Show("NO HAY REGISTRO");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }
        #endregion
        public List<Venta> GetVentas()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Venta> ventas = _context.Venta
                        .Include(x => x.Clientes)
                        .Include(x => x.Empleados) // Incluir Empleados sin filtrar por Estado
                        .Where(e => e.Empleados.Estado == 1) // Filtrar empleados por Estado
                        .ToList(); 
                    return ventas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Cliente> GetClientes()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Cliente> clientes = _context.Cliente.ToList();
                    return clientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Empleado> GetEmpleados()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Empleado> empleados = _context.Empleado
                        .Where(x=>x.FKPuesto == 2)
                        .Where(x=>x.Estado == 1)
                        .ToList();
                    return empleados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public Venta GetVentaById(int ventaId)
        {
            using (var context = new ApplicationDbContext())
            {
                // Suponiendo que DbSet "Venta" representa la tabla de ventas en la base de datos.
                var venta = context.Venta.Find(ventaId);
                return venta;
            }
        }
        public Producto GetProctoByName(int productoname)
        {
            using (var context = new ApplicationDbContext())
            {
                // Suponiendo que DbSet "Producto" representa la tabla de productos en la base de datos.
                var produc = context.Producto.Find(productoname);
                return produc;
            }
        }
    }
}