using System;
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
using CancelTrack.Entities;
using CancelTrack.Services;

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
        EmpleadoServices services = new EmpleadoServices();
        private void BtnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKEmpleado.Text == "")
            {
                Empleado usuario = new Empleado();
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Matricula = txtMatricula.Text;
                usuario.Contraseña = txtContraseña.Text;
                usuario.Telefono = int.Parse(txtTelefono.Text);
                usuario.Correo = txtCorreo.Text;
                usuario.FKPuesto = int.Parse(CbxPuesto.SelectedValue.ToString());

                services.Add(usuario);
                MessageBox.Show("Usuario registrado");
                txtNombre.Clear();
                txtApellido.Clear();
                txtMatricula.Clear();
                txtContraseña.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtPKEmpleado.Clear();
                CbxPuesto.SelectedItem = null;
                GetEmpleadosTable();
            }
            else
            {
                int Id = Convert.ToInt32(txtPKEmpleado.Text);
                Empleado usuario = new Empleado()
                {
                    PKEmpleado = Id,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Matricula = txtMatricula.Text,
                    Contraseña = txtContraseña.Text,
                    Telefono = int.Parse(txtTelefono.Text),
                    Correo = txtCorreo.Text,
                    FKPuesto = int.Parse(CbxPuesto.SelectedValue.ToString())
                };
                services.Update(usuario);
                MessageBox.Show("Usuario actualizado");
                GetEmpleadosTable();
                txtNombre.Clear();
                txtApellido.Clear();
                txtMatricula.Clear();
                txtContraseña.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtPKEmpleado.Clear();
                CbxPuesto.SelectedItem = null;
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
    }
}
