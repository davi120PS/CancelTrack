using CancelTrack.Context;
using CancelTrack.Entities;
using CancelTrack.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
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
        private readonly ProductoServices productoServices = new ProductoServices();
        private readonly VentaServices VentaServices = new VentaServices();
        Venta venta = new Venta();
        Producto producto = new Producto();

        public CRUDVentaProducto()
        {
            InitializeComponent();
            GetVentasProductosTable();
            GetVenta();
            GetProducto();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKVentaProducto.Text == "")
            {
                if (!string.IsNullOrEmpty(txtCantidadVP.Text) && CbxFKProducto.SelectedValue != null && CbxFKVenta.SelectedValue != null &&
                    int.TryParse(txtCantidadVP.Text, out int cantidad))
                {
                    var ventaProducto = new VentaProducto()
                    {   //Agrega los datos ingresados a la base de datos
                        FKProducto = int.Parse(CbxFKProducto.SelectedValue.ToString()),
                        FKVentas = int.Parse(CbxFKVenta.SelectedValue.ToString()),
                        Cantidad = cantidad
                    };
                    services.Add(ventaProducto);

                    // Recalcular el valor del Total de la venta
                    venta = VentaServices.GetVentaById(int.Parse(CbxFKVenta.SelectedValue.ToString()));
                    producto = VentaServices.GetProctoByName(int.Parse(CbxFKProducto.SelectedValue.ToString()));
                    int totalVenta = CalcularTotalVenta(producto.PrecioVenta, cantidad);

                    // Sumar el valor calculado al Total existente
                    venta.Total += totalVenta;

                    Venta ventaTotal = new Venta()
                    {
                        PKVenta = int.Parse(CbxFKVenta.SelectedValue.ToString()),
                        Total = venta.Total
                    };
                    VentaServices.UpdateTotal(ventaTotal);

                    MessageBox.Show("Producto agregado a la venta");
                    GetVentasProductosTable();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show("Faltan datos por llenar");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKVentaProducto.Text);
                if (int.TryParse(txtCantidadVP.Text, out int cantidad))
                {
                    VentaProducto ventaProducto = new VentaProducto
                    {
                        PKVentaProducto = Id,
                        FKProducto = int.Parse(CbxFKProducto.SelectedValue.ToString()),
                        Cantidad = cantidad
                    };
                    services.Update(ventaProducto);

                    MessageBox.Show("Venta del producto actualizada");
                    GetVentasProductosTable();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show("El formato de cantidad es incorrecto.");
            }
        }
        private int CalcularTotalVenta(int precioVenta, int cantidad)
        {
            return precioVenta * cantidad;
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKVentaProducto.Text == "")
                MessageBox.Show("Selecciona una venta del producto");
            else
            {
                try
                {
                    int ventaProductoId = int.Parse(txtPKVentaProducto.Text);
                    VentaProducto ventaProducto = services.GetVentaProductos().FirstOrDefault(vp => vp.PKVentaProducto == ventaProductoId);

                    if (ventaProducto != null)
                    {
                        int ventaId = ventaProducto.FKVentas;
                        Producto producto = ventaProducto.Productos;
                        int cantidadEliminada = ventaProducto.Cantidad;

                        services.Delete(ventaProductoId); // Eliminar la VentaProducto

                        // Actualizar el Total y el Inventario
                        VentaServices.UpdateTotalAndInventoryAfterDeletion(ventaId, new List<VentaProducto> { ventaProducto });

                        MessageBox.Show("Venta del producto eliminada y Total e Inventario actualizados");
                        GetVentasProductosTable();
                        LimpiarCampos();
                    }
                    else
                        MessageBox.Show("No se encontró la venta del producto");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la venta del producto: " + ex.Message);
                }
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
            TablaVentaProducto.ItemsSource = services.GetVentaProductos();
            /*/ Obtener la lista de productos relacionados a ventas de empleados activos
            var ventaProductosFiltrados = services.GetVentaProductos()
                .Where(vp => vp.Ventas.Empleados.Estado == 1)
                .ToList();

            // Asignar la lista filtrada a la propiedad ItemsSource de la tabla
            TablaVentaProducto.ItemsSource = ventaProductosFiltrados;*/
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
            txtPKVentaProducto.Clear();
            txtCantidadVP.Clear();
            CbxFKProducto.SelectedValue = null;
            CbxFKVenta.SelectedValue = null;
        }
        public void LimpiarCampos()
        {
            txtPKVentaProducto.Clear();
            txtCantidadVP.Clear();
            CbxFKProducto.SelectedValue = null;
            CbxFKVenta.SelectedValue = null;
        }
    }
}