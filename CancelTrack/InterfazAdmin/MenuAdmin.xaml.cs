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

        private void txtEmpleados_Click(object sender, RoutedEventArgs e)
        {
            CRUDEmpleado vista = new CRUDEmpleado();
            vista.Show();
            Close();
        }

        private void txtClientes_Click(object sender, RoutedEventArgs e)
        {
            CRUDCliente vista = new CRUDCliente();
            vista.Show();
            Close();
        }

        private void txtProductos_Click(object sender, RoutedEventArgs e)
        {
            CRUDProducto vista = new CRUDProducto();
            vista.Show();
            Close();
        }

        private void txtVentas_Click(object sender, RoutedEventArgs e)
        {
            CRUDVenta vista = new CRUDVenta();
            vista.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow vista = new MainWindow();
            vista.Show();
            Close();
        }
    }
}
