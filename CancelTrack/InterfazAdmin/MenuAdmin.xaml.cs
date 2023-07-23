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
    /// Lógica de interacción para MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void BtnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            CRUDEmpleado vista = new CRUDEmpleado();
            vista.Show();
            Close();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            CRUDCliente vista = new CRUDCliente();
            vista.Show();
            Close();
        }

        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            CRUDProducto vista = new CRUDProducto();
            vista.Show();
            Close();
        }

        private void BtnVentas_Click(object sender, RoutedEventArgs e)
        {
            CRUDVenta vista = new CRUDVenta();
            vista.Show();
            Close();
        }

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            MainWindow vista = new MainWindow();
            vista.Show();
            Close();
        }

        private void BtnProveedores_Click(object sender, RoutedEventArgs e)
        {
            CRUDProveedor vista = new CRUDProveedor();
            vista.Show();
            Close();
        }

        private void txtVentasProducto_Click(object sender, RoutedEventArgs e)
        {
            CRUDVentaProducto vista = new CRUDVentaProducto();
            vista.Show();
            Close();
        }
    }
}
