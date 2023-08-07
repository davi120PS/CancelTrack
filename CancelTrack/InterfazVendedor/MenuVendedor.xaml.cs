using CancelTrack.InterfazAdmin;
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
    /// Lógica de interacción para MenuVendedor.xaml
    /// </summary>
    public partial class MenuVendedor : Window
    {
        public MenuVendedor()
        {
            InitializeComponent();
        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            CRUCliente VendedorCliente = new CRUCliente();
            VendedorCliente.Show();
            Hide();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Login = new MainWindow();
            Login.Show();
            Close();
        }

        private void BtnVentaProducto_Click(object sender, RoutedEventArgs e)
        {
            CRUDVentaProductoV VendedorVP = new CRUDVentaProductoV();
            VendedorVP.Show();
            Hide();
        }

        private void BtnVenta_Click(object sender, RoutedEventArgs e)
        {
            CRUVenta VendedorVenta = new CRUVenta();
            VendedorVenta.Show();
            Hide();
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
