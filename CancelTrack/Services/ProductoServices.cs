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
    public class ProductoServices
    {
        #region ADD
        public void Add(Producto request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Producto res = new Producto();
                        res.Nombre = request.Nombre;
                        res.FKProveedor = request.FKProveedor;
                        res.Descripcion = request.Descripcion;
                        res.PrecioVenta = request.PrecioVenta;
                        res.PrecioCompra = request.PrecioCompra;
                        res.CantidadInventario = request.CantidadInventario;
                        _context.Producto.Add(res);
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
        public void Update(Producto request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Producto update = _context.Producto.Find(request.PKProducto);
                    update.Nombre = request.Nombre;
                    update.FKProveedor = request.FKProveedor;
                    update.Descripcion = request.Descripcion;
                    update.PrecioVenta = request.PrecioVenta;
                    update.PrecioCompra = request.PrecioCompra;
                    update.CantidadInventario = request.CantidadInventario;

                    //_context.Entry(update).State = EntityState.Modified;
                    _context.Producto.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        #endregion
        public void UpdateCantidadInventario(int productoId, int cantidadVendida)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Producto producto = _context.Producto.Find(productoId);
                    if (producto != null)
                    {
                        // Disminuir la cantidad en inventario del producto según la cantidad vendida
                        producto.CantidadInventario -= cantidadVendida;
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        #region DELETE
        public void Delete(int ProductoId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Producto producto = _context.Producto.Find(ProductoId);
                    if (producto != null)
                    {
                        _context.Remove(producto);
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
        public List<Producto> GetProductos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Producto> productos = _context.Producto.Include(x => x.Proveedor).ToList();
                    return productos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Proveedor> GetProveedores()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Proveedor> proveedores = _context.Proveedor.ToList();
                    return proveedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
    }
}