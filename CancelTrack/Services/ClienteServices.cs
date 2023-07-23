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
    public class ClienteServices
    {
        #region ADD
        public void Add(Cliente request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Nombre = request.Nombre;
                        cliente.Apellido = request.Apellido;
                        cliente.Direccion = request.Direccion;
                        cliente.Telefono = request.Telefono;
                        cliente.Correo = request.Correo;
                        _context.Cliente.Add(cliente);
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
        public void Update(Cliente request)//recibe todos los datos del empleado
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Cliente update = _context.Cliente.Find(request.PKCliente);
                    update.Nombre = request.Nombre;
                    update.Apellido = request.Apellido;
                    update.Direccion = request.Direccion;
                    update.Telefono = request.Telefono;
                    update.Correo = request.Correo;

                    //_context.Entry(update).State = EntityState.Modified;
                    _context.Cliente.Update(update);
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
        public void Delete(int ClienteId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Cliente cliente = _context.Cliente.Find(ClienteId);
                    if (cliente != null)
                    {
                        _context.Remove(cliente);
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
        public List<Cliente> GetClientes()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Cliente> cliente = _context.Cliente.ToList();
                    return cliente;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
    }
}