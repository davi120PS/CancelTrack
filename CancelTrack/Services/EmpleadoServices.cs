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
    public class EmpleadoServices
    {
        #region LOGIN
        public Empleado Login(string UserName, string Password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var usuario = _context.Empleado.Include(y => y.Puestos).FirstOrDefault(x => x.Matricula == UserName && x.Contraseña == Password);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }
        #endregion
        #region ADD
        public void Add(Empleado request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Empleado res = new Empleado();
                        res.Nombre = request.Nombre;
                        res.Apellido = request.Apellido;
                        res.Matricula = request.Matricula;
                        res.Contraseña = request.Contraseña;
                        res.Telefono = request.Telefono;
                        res.Correo = request.Correo;
                        res.Estado = 1;
                        res.FKPuesto = request.FKPuesto;
                        _context.Empleado.Add(res);
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
        public void Update(Empleado request)//recibe todos los datos del empleado
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado update = _context.Empleado.Find(request.PKEmpleado);
                    update.Nombre = request.Nombre;
                    update.Apellido = request.Apellido;
                    update.Contraseña = request.Contraseña;
                    update.FKPuesto = request.FKPuesto;
                    update.Telefono = request.Telefono;
                    update.Correo = request.Correo;
                    update.Estado = request.Estado;

                    //_context.Entry(update).State = EntityState.Modified;
                    _context.Empleado.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public void UpdateEstado(Empleado request)//recibe todos los datos del empleado
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado update = _context.Empleado.Find(request.PKEmpleado);
                    update.Estado = request.Estado;

                    _context.Empleado.Update(update);
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
        public void Delete(int EmpleadoId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado usuario = _context.Empleado.Find(EmpleadoId);
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
        public List<Empleado> GetEmpleados()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Empleado> empleados = _context.Empleado
                        .Where(e => e.Estado == 1) // Filtra por Estado = 1
                        .Include(x => x.Puestos)
                        .ToList();
                    return empleados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Puesto> GetPuestos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Puesto> puestos = _context.Puesto.ToList();
                    return puestos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
    }
}