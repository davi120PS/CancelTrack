using CancelTrack.Entities;
using CancelTrack.InterfazVendedor;
using CancelTrack.Services;
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

namespace CancelTrack.InterfazAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDProveedor.xaml
    /// </summary>
    public partial class CRUDProveedor : Window
    {
        public CRUDProveedor()
        {
            InitializeComponent();
            GetProveedorTable();
        }
        ProveedorServices services = new ProveedorServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKProveedor.Text == "")
            {
                if (txtNombreProv.Text != "" || txtDireccionProv.Text != "" && txtTelefonoProv.Text != "" && txtCorreoProv.Text != "")
                {
                    Proveedor proveedor = new Proveedor()
                    {
                        Nombre = txtNombreProv.Text,
                        Direccion = txtDireccionProv.Text,
                        Telefono = int.Parse(txtTelefonoProv.Text),
                        Correo = txtCorreoProv.Text
                    };

                    services.Add(proveedor);
                    MessageBox.Show("Proveedor registrado");
                    GetProveedorTable();
                }
                else
                    MessageBox.Show("Faltan datos por llenar");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKProveedor.Text);
                Proveedor proveedor = new Proveedor()
                {
                    PKProveedor = Id,
                    Nombre = txtNombreProv.Text,
                    Direccion = txtDireccionProv.Text,
                    Telefono = int.Parse(txtTelefonoProv.Text),
                    Correo = txtCorreoProv.Text
                };
                MessageBox.Show("Proveedor actualizado");
                services.Update(proveedor);
            }
            GetProveedorTable();
            txtPKProveedor.Clear();
            txtNombreProv.Clear();
            txtDireccionProv.Clear();
            txtTelefonoProv.Clear();
            txtCorreoProv.Clear();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKProveedor.Text == "")
            {
                MessageBox.Show("Selecciona un proveedor");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKProveedor.Text);
                Proveedor proveedor = new Proveedor();
                proveedor.PKProveedor = Id;
                services.Delete(Id);
                MessageBox.Show("Proveedor Eliminado");
                GetProveedorTable();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Proveedor proveedor = new Proveedor();

            proveedor = (sender as FrameworkElement).DataContext as Proveedor;

            txtPKProveedor.Text = proveedor.PKProveedor.ToString();
            txtNombreProv.Text = proveedor.Nombre.ToString();
            txtDireccionProv.Text = proveedor.Direccion.ToString();
            txtTelefonoProv.Text = proveedor.Telefono.ToString();
            txtCorreoProv.Text = proveedor.Correo.ToString();
        }
        public void GetProveedorTable()
        {
            TablaProveedor.ItemsSource = services.GetProveedores();
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
                txtPKProveedor.Clear();
                txtNombreProv.Clear();
                txtDireccionProv.Clear();
                txtTelefonoProv.Clear();
                txtCorreoProv.Clear();
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
    }
}
