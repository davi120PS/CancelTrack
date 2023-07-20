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
                        res.Puestos = request.Puestos;
                        res.Telefono = request.Telefono;
                        res.Correo = request.Correo;
                        _context.Empleado.Add(res);
                        _context.SaveChanges();
                        /*Usuarios res = new Usuarios()
						{
							Name = request.Name,
							UserName = request.UserName,
							Password = request.Password
						};*/
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
                    List<Empleado> usuarios = _context.Empleado.Include(x => x.Puestos).ToList();
                    return usuarios;
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
                    List<Puesto> roles = _context.Puesto.ToList();
                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
    }
}