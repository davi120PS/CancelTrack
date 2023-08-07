using CancelTrack.Entities;
using CancelTrack.InterfazAdmin;
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

namespace CancelTrack.InterfazVendedor
{
    /// <summary>
    /// Lógica de interacción para CRUVenta.xaml
    /// </summary>
    public partial class CRUVenta : Window
    {
        public CRUVenta()
        {
            InitializeComponent();
            GetVentaTable();
            GetCliente();
            GetEmpleado();
        }
        VentaServices services = new VentaServices();
        CRUDVentaProducto TablaVentaProducto = new CRUDVentaProducto();
        VentaProductoServices ventaProductoServices = new VentaProductoServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtTotalVen.Text == "")
            {
                if (CbxFKCliente.SelectedValue != null && CbxFKEmpleado.SelectedValue != null)
                {
                    Venta venta = new Venta()
                    {
                        FKCliente = int.Parse(CbxFKCliente.SelectedValue.ToString()),
                        FKEmpleado = int.Parse(CbxFKEmpleado.SelectedValue.ToString()),
                        VentaProductos = new List<VentaProducto>() // Inicializar la lista de VentaProductos
                    };
                    services.Add(venta);

                    MessageBox.Show("Venta registrada");
                    GetVentaTable();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show("Faltan datos por llenar");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKVenta.Text);
                Venta venta = new Venta()
                {
                    PKVenta = Id,
                    FKCliente = int.Parse(CbxFKCliente.SelectedValue.ToString()),
                    FKEmpleado = int.Parse(CbxFKEmpleado.SelectedValue.ToString()),
                };
                services.Update(venta);

                MessageBox.Show("Venta actualizada");
                GetVentaTable();
                LimpiarCampos();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Venta venta = new Venta();

            venta = (sender as FrameworkElement).DataContext as Venta;

            txtPKVenta.Text = venta.PKVenta.ToString();
            CbxFKCliente.SelectedValue = venta.FKCliente.ToString();
            CbxFKEmpleado.SelectedValue = venta.FKEmpleado.ToString();
            txtTotalVen.Text = venta.Total.ToString();
        }

        public void GetVentaTable()
        {
            TablaVenta.ItemsSource = services.GetVentas();
        }
        public void GetCliente()
        {
            CbxFKCliente.ItemsSource = services.GetClientes();
            CbxFKCliente.DisplayMemberPath = "Nombre";
            CbxFKCliente.SelectedValuePath = "PKCliente";
        }
        public void GetEmpleado()
        {
            CbxFKEmpleado.ItemsSource = services.GetEmpleados();
            CbxFKEmpleado.DisplayMemberPath = "Nombre";
            CbxFKEmpleado.SelectedValuePath = "PKEmpleado";
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuVendedor admin = new MenuVendedor();
            admin.Show();
            Close();
        }
        public void LimpiarCampos()
        {
            txtPKVenta.Clear();
            txtTotalVen.Clear();
            CbxFKCliente.SelectedValue = null;
            CbxFKEmpleado.SelectedValue = null;
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtPKVenta.Clear();
            txtTotalVen.Clear();
            CbxFKCliente.SelectedValue = null;
            CbxFKEmpleado.SelectedValue = null;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}