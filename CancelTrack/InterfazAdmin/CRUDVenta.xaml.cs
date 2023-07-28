using CancelTrack.Entities;
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
    /// Lógica de interacción para CRUDVenta.xaml
    /// </summary>
    public partial class CRUDVenta : Window
    {
        public CRUDVenta()
        {
            InitializeComponent();
            GetVentaTable();
            GetCliente();
            GetEmpleado();
            //GetVentaProducto();
        }
        VentaServices services = new VentaServices();
        CRUDVentaProducto TablaVentaProducto = new CRUDVentaProducto();
        VentaProductoServices ventaProductoServices = new VentaProductoServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtTotalVen.Text == "")
            {
                if (CbxFKCliente.SelectedValue != null || CbxFKEmpleado.SelectedValue != null)
                {
                    Venta venta = new Venta()
                    {
                        FKCliente = int.Parse(CbxFKCliente.SelectedValue.ToString()),
                        FKEmpleado = int.Parse(CbxFKEmpleado.SelectedValue.ToString()),
                        VentaProductos = new List<VentaProducto>() // Inicializar la lista de VentaProductos
                    };

                    // Calcular el total de la venta y asignarlo a la propiedad Total de la entidad Venta
                    int totalVenta = 0;
                    foreach (var ventaProducto in venta.VentaProductos)
                    {
                        totalVenta += ventaProducto.Cantidad * ventaProducto.Productos.PrecioVenta;
                    }
                    venta.Total = totalVenta;

                    services.Add(venta);

                    MessageBox.Show("Venta y VentaProducto registrada");
                    GetVentaTable();
                    txtPKVenta.Clear();
                    txtTotalVen.Clear();
                    CbxFKCliente.SelectedValue = null;
                    CbxFKEmpleado.SelectedValue = null;
                    //CbxFKVentaProducto.SelectedValue = null;
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
                    Total = int.Parse(txtTotalVen.Text),
                    FKCliente = int.Parse(CbxFKCliente.SelectedValue.ToString()),
                    FKEmpleado = int.Parse(CbxFKEmpleado.SelectedValue.ToString()),
                };

                services.Update(venta);
                MessageBox.Show("Venta actualizada");
                GetVentaTable();
                txtPKVenta.Clear();
                txtTotalVen.Clear();
                CbxFKCliente.SelectedValue = null;
                CbxFKEmpleado.SelectedValue = null;
                //CbxFKVentaProducto.SelectedValue = null;
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKVenta.Text == "")
            {
                MessageBox.Show("Selecciona un venta");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKVenta.Text);
                Venta venta = new Venta();
                venta.PKVenta = Id;
                services.Delete(Id);
                MessageBox.Show("Venta eliminada");
                GetVentaTable();
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
        /*public void GetVentaProducto()
        {
            CbxFKVentaProducto.ItemsSource = services.GetVentaProductos();
            CbxFKVentaProducto.DisplayMemberPath = "PKVentaProducto";
            CbxFKVentaProducto.SelectedValuePath = "PKVentaProducto";
        }*/
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
                txtPKVenta.Clear();
                txtTotalVen.Clear();
                CbxFKCliente.SelectedValue = null;
                CbxFKEmpleado.SelectedValue = null;
                //CbxFKVentaProducto.SelectedValue = null;
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
    }
}