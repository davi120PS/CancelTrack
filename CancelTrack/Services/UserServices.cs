using CancelTrack.Context;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CancelTrack.Services
{
    public class UserServices
    {
        public void AddUser(Usuarios request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Usuarios res = new Usuarios();
                        res.Name = request.Name;
                        res.UserName = request.UserName;
                        res.Password = request.Password;
                        res.FKRol = request.FKRol;
                        _context.Usuarios.Add(res);
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
        public void Update(Usuarios request)//recibe todos los datos del empleado
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuarios update = _context.Usuarios.Find(request.PKUser);
                    update.Name = request.Name;
                    update.UserName = request.UserName;
                    update.Password = request.Password;
                    update.FKRol = request.FKRol;

                    //_context.Entry(update).State = EntityState.Modified;
                    _context.Usuarios.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public void DeleteUser(int UserId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuarios usuario = _context.Usuarios.Find(UserId);
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
        public List<Usuarios> GetUsers()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Usuarios> usuarios = _context.Usuarios.Include(x => x.Roles).ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = _context.Rol.ToList();
                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public Usuarios Login(string UserName, string Password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var usuario = _context.Usuarios.Include(y => y.Roles).FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }
    }
}
