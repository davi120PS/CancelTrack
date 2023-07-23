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
        public void Update(VentaProducto request)//recibe todos los datos del VentaProducto
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    VentaProducto update = _context.VentaProducto.Find(request.PKVentaProducto);
                    update.Cantidad = request.Cantidad;
                    update.FKProducto = request.FKProducto;

                    //_context.Entry(update).State = EntityState.Modified;
                    _context.VentaProducto.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        #endregion
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
        public List<VentaProducto> GetVentaProductos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<VentaProducto> ventaProductos = _context.VentaProducto.Include(x => x.Productos).ToList();
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