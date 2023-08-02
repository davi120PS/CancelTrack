using CancelTrack.Context;
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
        private readonly VentaProductoServices services = new VentaProductoServices();
        ProductoServices productoServices = new ProductoServices();
        public CRUDVentaProducto()
        {
            InitializeComponent();
            GetVentasProductosTable();
            GetVenta();
            GetProducto();
        }
        VentaServices VentaServices = new VentaServices();
        Venta venta = new Venta();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKVentaProducto.Text == "")
            {
                if (txtCantidadVP.Text != "" || CbxFKProducto.SelectedValue != null)
                {
                    VentaProducto ventaProducto = new VentaProducto()
                    {   //Agrega los datos ingresados a la base de datos
                        FKProducto = int.Parse(CbxFKProducto.SelectedValue.ToString()),
                        FKVentas = int.Parse(CbxFKVenta.SelectedValue.ToString()),
                        Cantidad = int.Parse(txtCantidadVP.Text)
                    };
                    services.Add(ventaProducto);
                    // Recalcular el valor del Total de la venta
                    venta = VentaServices.GetVentaById(int.Parse(CbxFKVenta.SelectedValue.ToString()));
                    Producto producto = VentaServices.GetProctoByName(int.Parse(CbxFKProducto.SelectedValue.ToString()));
                    int totalVenta = CalcularTotalVenta(venta, producto, int.Parse(txtCantidadVP.Text));
                    venta.Total += totalVenta;
                    Venta ventaTotal = new Venta()
                    {
                        PKVenta = int.Parse(CbxFKVenta.SelectedValue.ToString()),
                        Total = totalVenta
                    };
                    VentaServices.UpdateTotal(ventaTotal);

                    // Actualizar la cantidad de inventario del producto
                    int productoId = int.Parse(CbxFKProducto.SelectedValue.ToString());
                    int cantidadVendida = int.Parse(txtCantidadVP.Text);
                    productoServices.UpdateCantidadInventario(productoId, cantidadVendida);

                    MessageBox.Show("Producto agregado a la venta");
                    GetVentasProductosTable();
                    
                    txtPKVentaProducto.Clear();
                    txtCantidadVP.Clear();  
                    CbxFKVenta.SelectedValue = null;
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

                // Recalcular el valor del Total de la venta
                venta = VentaServices.GetVentaById(int.Parse(CbxFKVenta.SelectedValue.ToString()));
                Producto producto = VentaServices.GetProctoByName(int.Parse(CbxFKProducto.SelectedValue.ToString()));
                int totalVenta = CalcularTotalVenta(venta, producto, int.Parse(txtCantidadVP.Text));
                venta.Total = totalVenta;

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
        private int CalcularTotalVenta(Venta venta, Producto producto, int ventacant)
        {
            int totalVenta = 0;

            totalVenta += producto.PrecioVenta * ventacant;
            
            return totalVenta;
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKVentaProducto.Text == "")
                MessageBox.Show("Selecciona un venta del producto");
            else
            {
                int Id = Convert.ToInt32(txtPKVentaProducto.Text);
                VentaProducto venta = new VentaProducto();
                venta.PKVentaProducto = Id;
                services.Delete(Id);

                /*// Recalcular el valor del Total de la venta
                Venta venta = VentaServices.GetVentaById(int.Parse(CbxFKVenta.SelectedValue.ToString()));
                int totalVenta = CalcularTotalVenta(venta);
                venta.Total = totalVenta;*/
                MessageBox.Show("Venta del producto Eliminada");
                GetVentasProductosTable();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            VentaProducto ventaProducto = new VentaProducto();
            ventaProducto = (sender as FrameworkElement).DataContext as VentaProducto;
            txtPKVentaProducto.Text = ventaProducto.PKVentaProducto.ToString();
            CbxFKVenta.SelectedValue = ventaProducto.FKVentas.ToString();
            CbxFKProducto.SelectedValue = ventaProducto.FKProducto.ToString();
            txtCantidadVP.Text = ventaProducto.Cantidad.ToString();
        }
        public void GetVentasProductosTable()
        {
            //List<VentaProducto> ventaProductos = services.GetVentaProductos();
            //TablaVentaProducto.ItemsSource = ventaProductos;
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
            CbxFKVenta.ItemsSource = services.GetVentas();
            CbxFKVenta.DisplayMemberPath = "PKVenta";
            CbxFKVenta.SelectedValuePath = "PKVenta";
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