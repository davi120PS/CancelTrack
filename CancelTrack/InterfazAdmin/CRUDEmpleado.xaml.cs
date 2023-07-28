﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CancelTrack.Context;
using CancelTrack.Entities;
using CancelTrack.Services;
using Org.BouncyCastle.Asn1.Ocsp;

namespace CancelTrack.InterfazAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDEmpleado.xaml
    /// </summary>
    public partial class CRUDEmpleado : Window
    {
        public CRUDEmpleado()
        {
            InitializeComponent();
            GetEmpleadosTable();
            GetPuesto();
        }
        static int estado = 0;
        EmpleadoServices services = new EmpleadoServices();
        private void BtnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKEmpleado.Text == "")
            {
                if (txtNombre.Text != "" || txtApellido.Text != "" || txtMatricula.Text != "" || txtContraseña.Text != "" || txtTelefono.Text != "" || txtCorreo.Text != "" || CbxPuesto.SelectedValue != null)
                {
                    Empleado empleado = new Empleado();
                    empleado.Nombre = txtNombre.Text;
                    empleado.Apellido = txtApellido.Text;
                    empleado.Matricula = txtMatricula.Text;
                    empleado.Contraseña = txtContraseña.Text;
                    empleado.Telefono = int.Parse(txtTelefono.Text);
                    empleado.Correo = txtCorreo.Text;
                    //empleado.Estado = 1;
                    empleado.FKPuesto = int.Parse(CbxPuesto.SelectedValue.ToString());

                    services.Add(empleado);
                    MessageBox.Show("Empleado registrado");

                    txtPKEmpleado.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtMatricula.Clear();
                    txtContraseña.Clear();
                    txtTelefono.Clear();
                    txtCorreo.Clear();
                    CbxPuesto.SelectedItem = null;
                    GetEmpleadosTable();
                }
                else
                    MessageBox.Show("Faltan datos por llenar");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKEmpleado.Text);
                Empleado empleado = new Empleado()
                {
                    PKEmpleado = Id,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Matricula = txtMatricula.Text,
                    Contraseña = txtContraseña.Text,
                    Telefono = int.Parse(txtTelefono.Text),
                    Correo = txtCorreo.Text,
                    Estado = 1,
                    FKPuesto = int.Parse(CbxPuesto.SelectedValue.ToString())
                };
                services.Update(empleado);
                MessageBox.Show("Empleado actualizado");
                GetEmpleadosTable();
                txtPKEmpleado.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtMatricula.Clear();
                txtContraseña.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                CbxPuesto.SelectedItem = null;
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Empleado empleados = new Empleado();
            empleados = (sender as FrameworkElement).DataContext as Empleado;
            txtPKEmpleado.Text = empleados.PKEmpleado.ToString();
            txtNombre.Text = empleados.Nombre.ToString();
            txtApellido.Text = empleados.Apellido.ToString();
            txtMatricula.Text = empleados.Matricula.ToString();
            txtContraseña.Text = empleados.Contraseña.ToString();
            txtTelefono.Text = empleados.Telefono.ToString();
            txtCorreo.Text = empleados.Correo.ToString();
            CbxPuesto.SelectedValue = empleados.FKPuesto.ToString();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKEmpleado.Text == "")
            {
                MessageBox.Show("Selecciona un usuario");
            }
            else
            {
                int userId = Convert.ToInt32(txtPKEmpleado.Text);
                Empleado empleados = new Empleado();
                empleados.PKEmpleado = userId;
                services.Delete(userId);
                MessageBox.Show("Usuario Eliminado");
                GetEmpleadosTable();
            }
        }

        private void BtnDarBaja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPKEmpleado.Text == "")
                {
                    MessageBox.Show("Selecciona un usuario");
                }
                else
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        int Id = Convert.ToInt32(txtPKEmpleado.Text);
                        Empleado empleado = new Empleado()
                        {
                            PKEmpleado = Id,
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Matricula = txtMatricula.Text,
                            Contraseña = txtContraseña.Text,
                            Telefono = int.Parse(txtTelefono.Text),
                            Correo = txtCorreo.Text,
                            Estado = 0,
                            FKPuesto = int.Parse(CbxPuesto.SelectedValue.ToString())
                        };
                        services.Update(empleado);
                        MessageBox.Show("Empleado dado de baja");
                        GetEmpleadosTable();
                        txtPKEmpleado.Clear();
                        txtNombre.Clear();
                        txtApellido.Clear();
                        txtMatricula.Clear();
                        txtContraseña.Clear();
                        txtTelefono.Clear();
                        txtCorreo.Clear();
                        CbxPuesto.SelectedItem = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public void GetEmpleadosTable()
        {
            TablaEmpleado.ItemsSource = services.GetEmpleados();
        }
        public void GetPuesto()
        {
            CbxPuesto.ItemsSource = services.GetPuestos();
            CbxPuesto.DisplayMemberPath = "Nombre";
            CbxPuesto.SelectedValuePath = "PKPuesto";
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin admin = new MenuAdmin();
            admin.Show();
            Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtPKEmpleado.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtMatricula.Clear();
                txtContraseña.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                CbxPuesto.SelectedValue = null;
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
    }
}