using CancelTrack.Context;
using CancelTrack.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CancelTrack.Services
{
    public class VentaProductoServices
    {
        VentaServices ventaServices = new VentaServices();
        #region ADD
        public void Add(VentaProducto request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        VentaProducto res = new VentaProducto();
                        res.Cantidad = request.Cantidad;
                        res.FKProducto = request.FKProducto;
                        res.FKVentas = request.FKVentas;
                        _context.VentaProducto.Add(res);
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
        public void Update(VentaProducto request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    VentaProducto update = _context.VentaProducto.Find(request.PKVentaProducto);
                    int cantidadAnterior = update.Cantidad; // Almacena la cantidad anterior para calcular la diferencia
                    
                    update.Cantidad = request.Cantidad;
                    update.FKProducto = request.FKProducto;

                    //_context.Entry(update).State = EntityState.Modified;
                    _context.VentaProducto.Update(update);
                    _context.SaveChanges();

                    // Actualizar el Total de la venta
                    Venta venta = _context.Venta.Find(update.FKVentas);
                    Producto producto = _context.Producto.Find(update.FKProducto);
                    int totalVenta = CalcularTotalVenta(venta, producto, request.Cantidad - cantidadAnterior);
                    
                    // Sumar el valor calculado al Total existente
                    venta.Total += totalVenta;
                    Venta totalCambiado = new Venta
                    {
                        PKVenta = update.FKVentas,
                        Total = venta.Total
                    };
                    ventaServices.UpdateTotal(totalCambiado);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        #endregion
        // Método para calcular el total de una venta después de cambios en VentaProducto
        private int CalcularTotalVenta(Venta venta, Producto producto, int cantidadCambiar)
        {
            int totalVenta = producto.PrecioVenta * cantidadCambiar;
            return totalVenta;
        }
        #region DELETE
        public void Delete(int VentaProductoId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    VentaProducto ventaProducto = _context.VentaProducto.Find(VentaProductoId);
                    if (ventaProducto != null)
                    {
                        _context.Remove(ventaProducto);
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("NO HAY REGISTRO");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
        #endregion
        public List<VentaProducto> GetVentaProductosByVentaId(int ventaId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    return _context.VentaProducto
                        .Include(vp => vp.Productos)
                        .Where(vp => vp.FKVentas == ventaId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos de la venta: " + ex.Message);
            }
        }
        public List<VentaProducto> GetVentaProductos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<VentaProducto> ventaProductos = _context.VentaProducto
                        .Include(x => x.Productos)
                        //.Include(x => x.Ventas)
                        .ToList();
                    return ventaProductos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Producto> GetProductos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Producto> productos = _context.Producto.ToList();
                    return productos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Venta> GetVentas()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Venta> ventas = _context.Venta.ToList();
                    return ventas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
    }
}