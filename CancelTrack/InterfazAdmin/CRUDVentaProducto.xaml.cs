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
    /// Lógica de interacción para CRUDVentaProducto.xaml
    /// </summary>
    public partial class CRUDVentaProducto : Window
    {
        public CRUDVentaProducto()
        {
            InitializeComponent();
            GetVentasProductosTable();
            GetVenta();
            GetProducto();
        }
        VentaProductoServices services = new VentaProductoServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductoServices productoServices = new ProductoServices();
            if (txtPKVentaProducto.Text == "")
            {
                if (txtCantidadVP.Text != "" || CbxFKProducto.SelectedValue != null)
                {
                    VentaProducto ventaProducto = new VentaProducto();
                    ventaProducto.Cantidad = int.Parse(txtCantidadVP.Text);
                    ventaProducto.FKProducto = int.Parse(CbxFKProducto.SelectedValue.ToString());

                    services.Add(ventaProducto);

                    // Actualizar la cantidad de inventario del producto
                    int productoId = int.Parse(CbxFKProducto.SelectedValue.ToString());
                    int cantidadVendida = int.Parse(txtCantidadVP.Text);
                    productoServices.UpdateCantidadInventario(productoId, cantidadVendida);

                    MessageBox.Show("Venta del producto registrada");
                    GetVentasProductosTable();
                    txtPKVentaProducto.Clear();
                    txtCantidadVP.Clear();
                    CbxFKProducto.SelectedValue = null;
                }
                else
                    MessageBox.Show("Faltan datos por llenar");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKVentaProducto.Text);
                VentaProducto ventaProducto = new VentaProducto()
                {
                    PKVentaProducto = Id,
                    Cantidad = int.Parse(txtCantidadVP.Text),
                    FKProducto = int.Parse(CbxFKProducto.SelectedValue.ToString())
                };
                services.Update(ventaProducto);

                // Actualizar la cantidad de inventario del producto
                int productoId = int.Parse(CbxFKProducto.SelectedValue.ToString());
                int cantidadVendida = int.Parse(txtCantidadVP.Text);
                productoServices.UpdateCantidadInventario(productoId, cantidadVendida);

                MessageBox.Show("Venta del producto actualizada");
                GetVentasProductosTable();
                txtPKVentaProducto.Clear();
                txtCantidadVP.Clear();
                CbxFKProducto.SelectedValue = null;
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKVentaProducto.Text == "")
            {
                MessageBox.Show("Selecciona un venta del producto");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKVentaProducto.Text);
                VentaProducto venta = new VentaProducto();
                venta.PKVentaProducto = Id;
                services.Delete(Id);
                MessageBox.Show("Venta del producto Eliminada");
                GetVentasProductosTable();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            VentaProducto ventaProducto = new VentaProducto();

            ventaProducto = (sender as FrameworkElement).DataContext as VentaProducto;

            txtPKVentaProducto.Text = ventaProducto.PKVentaProducto.ToString();
            txtCantidadVP.Text = ventaProducto.Cantidad.ToString();
            CbxFKProducto.SelectedValue = ventaProducto.FKProducto.ToString();
        }
        public void GetVentasProductosTable()
        {
            TablaVentaProducto.ItemsSource = services.GetVentaProductos();
        }
        public void GetProducto()
        {
            CbxFKProducto.ItemsSource = services.GetProductos();
            CbxFKProducto.DisplayMemberPath = "Nombre";
            CbxFKProducto.SelectedValuePath = "PKProducto";
        }
        public void GetVenta()
        {
            CbxFKProducto.ItemsSource = services.GetVentas();
            CbxFKProducto.DisplayMemberPath = "PKVenta";// si no sirve entonces es FKVenta
            CbxFKProducto.SelectedValuePath = "PKVenta";
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
                txtPKVentaProducto.Clear();
                txtCantidadVP.Clear();
                CbxFKProducto.SelectedValue = null;
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
    }
}
