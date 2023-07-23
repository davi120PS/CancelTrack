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
        }
        VentaServices services = new VentaServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKVenta.Text == "")
            {
                Venta venta = new Venta();
                //FKCliente = int.Parse(txtFKCliente.Text),
                //FKEmpleado = int.Parse(txtFKEmpleado.Text),
                venta.Total = int.Parse(txtTotal.Text);

                services.Add(venta);
                MessageBox.Show("Venta registrada");
                txtFKCliente.Clear();
                txtFKEmpleado.Clear();
                txtTotal.Clear();
                GetVentaTable();
            }
            else
            {
                int Id = Convert.ToInt32(txtPKVenta.Text);

                Venta venta = new Venta()
                {
                    PKVenta = Id,
                    FKCliente = int.Parse(txtFKCliente.Text),
                    FKEmpleado = int.Parse(txtFKEmpleado.Text),
                    Total = int.Parse(txtTotal.Text)
                };
                MessageBox.Show("Venta actualizado");
                services.Update(venta);
                txtPKVenta.Clear();
                txtFKCliente.Clear();
                txtFKEmpleado.Clear();
                txtTotal.Clear();
                GetVentaTable();
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKVenta.Text == "")
            {
                MessageBox.Show("Selecciona un proveedor");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKVenta.Text);
                Proveedor proveedor = new Proveedor();
                proveedor.PKProveedor = Id;
                services.Delete(Id);
                MessageBox.Show("Proveedor Eliminado");
                GetVentaTable();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Venta venta = new Venta();
            venta = (sender as FrameworkElement).DataContext as Venta;
            txtPKVenta.Text = venta.PKVenta.ToString();
            txtFKCliente.Text = venta.FKCliente.ToString();
            txtFKEmpleado.Text = venta.FKEmpleado.ToString();
            txtTotal.Text = venta.Total.ToString();
        }
        public void GetVentaTable()
        {
            VentaTable.ItemsSource = services.GetVentas();
        }
        private void UserTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
