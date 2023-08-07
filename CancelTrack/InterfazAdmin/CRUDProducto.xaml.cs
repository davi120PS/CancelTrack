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
    /// Lógica de interacción para CRUDProducto.xaml
    /// </summary>
    public partial class CRUDProducto : Window
    {
        public CRUDProducto()
        {
            InitializeComponent();
            GetProductoTable();
            GetProveedor();
        }
        ProductoServices services = new ProductoServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKProducto.Text == "")
            {
                if (txtNombreProd.Text != "" && txtDescripcionProd.Text != "" && txtPrecioVenta.Text != "" && txtPrecioCompra.Text != "" && txtCantInvenProd.Text != "" && CbxFKProv.SelectedValue != null)
                {
                    Producto producto = new Producto();
                    producto.Nombre = txtNombreProd.Text;
                    producto.Descripcion = txtDescripcionProd.Text;
                    producto.PrecioVenta = int.Parse(txtPrecioVenta.Text);
                    producto.PrecioCompra = int.Parse(txtPrecioCompra.Text);
                    producto.CantidadInventario = int.Parse(txtCantInvenProd.Text);
                    producto.FKProveedor = int.Parse(CbxFKProv.SelectedValue.ToString());

                    services.Add(producto);
                    MessageBox.Show("Producto registrado");
                    GetProductoTable();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show("Faltan datos por llenar");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKProducto.Text);
                Producto producto = new Producto()
                {
                    PKProducto = Id,
                    Nombre = txtNombreProd.Text,
                    Descripcion = txtDescripcionProd.Text,
                    PrecioVenta = int.Parse(txtPrecioVenta.Text),
                    PrecioCompra = int.Parse(txtPrecioCompra.Text),
                    CantidadInventario = int.Parse(txtCantInvenProd.Text),
                    FKProveedor = int.Parse(CbxFKProv.SelectedValue.ToString())
                };
                services.Update(producto);
                MessageBox.Show("Producto actualizado");
                GetProductoTable();
                LimpiarCampos();
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKProducto.Text == "")
            {
                MessageBox.Show("Selecciona un producto");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKProducto.Text);
                Producto producto = new Producto();
                producto.PKProducto = Id;
                services.Delete(Id);
                MessageBox.Show("Producto Eliminado");
                GetProductoTable();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Producto producto = new Producto();

            producto = (sender as FrameworkElement).DataContext as Producto;

            txtPKProducto.Text = producto.PKProducto.ToString();
            txtNombreProd.Text = producto.Nombre.ToString();
            txtDescripcionProd.Text = producto.Descripcion.ToString();
            txtPrecioVenta.Text = producto.PrecioVenta.ToString();
            txtPrecioCompra.Text = producto.PrecioCompra.ToString();
            txtCantInvenProd.Text = producto.CantidadInventario.ToString();
            CbxFKProv.SelectedValue = producto.FKProveedor.ToString();
        }
        public void GetProductoTable()
        {
            TablaProducto.ItemsSource = services.GetProductos();
        }
        public void GetProveedor()
        {
            CbxFKProv.ItemsSource = services.GetProveedores();
            CbxFKProv.DisplayMemberPath = "Nombre";
            CbxFKProv.SelectedValuePath = "PKProveedor";
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin admin = new MenuAdmin();
            admin.Show();
            Close();
        }
        public void LimpiarCampos()
        {
            txtPKProducto.Clear();
            txtNombreProd.Clear();
            txtDescripcionProd.Clear();
            txtPrecioVenta.Clear();
            txtPrecioCompra.Clear();
            txtCantInvenProd.Clear();
            CbxFKProv.SelectedValue = null;
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtPKProducto.Clear();
            txtNombreProd.Clear();
            txtDescripcionProd.Clear();
            txtPrecioVenta.Clear();
            txtPrecioCompra.Clear();
            txtCantInvenProd.Clear();
            CbxFKProv.SelectedValue = null;
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
