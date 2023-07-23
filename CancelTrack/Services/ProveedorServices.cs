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
    public class ProveedorServices
    {
        #region ADD
        public void Add(Proveedor request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Proveedor res = new Proveedor();
                        res.Nombre = request.Nombre;
                        res.Direccion = request.Direccion;
                        res.Telefono = request.Telefono;
                        res.Correo = request.Correo;
                        _context.Proveedor.Add(res);
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
        public void Update(Proveedor request)//recibe todos los datos del Proveedor
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Proveedor update = _context.Proveedor.Find(request.PKProveedor);
                    update.Nombre = request.Nombre;
                    update.Direccion = request.Direccion;
                    update.Telefono = request.Telefono;
                    update.Correo = request.Correo;

                    //_context.Entry(update).State = EntityState.Modified;
                    _context.Proveedor.Update(update);
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
        public void Delete(int ProveedorId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Proveedor proveedor = _context.Proveedor.Find(ProveedorId);
                    if (proveedor != null)
                    {
                        _context.Remove(proveedor);
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