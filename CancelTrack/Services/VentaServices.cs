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
                    List<Empleado> empleados = _context.Empleado.ToList();
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
                // Suponiendo que DbSet "Ventas" representa la tabla de ventas en la base de datos.
                var venta = context.Venta.Find(ventaId);
                return venta;
            }
        }
    }
}