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
    public class VentaServices
    {
        #region ADD
        public int Add(Venta request) // Modificamos el retorno para devolver la PKVenta generada
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
                        res.FKVentaProducto = request.FKVentaProducto;
                        res.Total = request.Total;
                        _context.Venta.Add(res);
                        _context.SaveChanges();

                        return res.PKVenta; // Devolvemos la PKVenta generada
                    }
                }
                return -1; // En caso de error
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
        #endregion
        #region DELETE
        public void Delete(int VentaId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Venta usuario = _context.Venta.Find(VentaId);
                    if (usuario != null)
                    {
                        _context.Remove(usuario);
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
        public List<Venta> GetVentas()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    //List<Venta> ventas = _context.Venta.Include(x => x.Clientes).Include(x => x.Empleados.Estado == 1).Include(x => x.VentaProductos).ToList();
                    List<Venta> ventas = _context.Venta
                        .Include(x => x.Clientes)
                        .Include(x => x.Empleados) // Incluir Empleados sin filtrar por Estado
                        .Where(e => e.Empleados.Estado == 1) // Filtrar empleados por Estado
                        .Include(x => x.VentaProductos).ToList();
                    //List<Venta> ventas2 = _context.Venta.Include(x => x.Empleados).Where(e => e.Empleados.Estado == 1).ToList();
                    /*List<Venta> ventas = _context.Venta
                        .Include(x => x.Clientes)
                        .Include(x => x.Empleados.Where(e => e.Estado == 1))
                        .Include(x => x.VentaProductos)
                        .ToList();*/

                    /*// Filtrar los empleados con Estado = 1 antes de incluirlos en la lista
                    foreach (var venta in ventas)
                    {
                        venta.Empleados = venta.Empleados.Where(e => e.Estado == 1).ToList();
                    }*/

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
                    List<Empleado> empleados = _context.Empleado.ToList();
                    return empleados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<VentaProducto> GetVentaProductos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<VentaProducto> ventaProductos = _context.VentaProducto.ToList();
                    return ventaProductos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
    }
}