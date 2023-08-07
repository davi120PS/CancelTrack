using CancelTrack.InterfazVendedor;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CancelTrack.Services;
using CancelTrack.Context;
using CancelTrack.Entities;

namespace CancelTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        EmpleadoServices services = new EmpleadoServices();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUserName.Text;
            string pass = txtPassword.Password;

            var response = services.Login(user, pass);

            if (txtUserName.Text != "" && txtPassword.Password != "")
            {
                if (response != null)
                {
                    if (response.Puestos.Nombre == "Admin")
                    {
                        try
                        {
                            using (var _context = new ApplicationDbContext())
                            {
                                Empleado empleado = new Empleado()
                                {
                                    PKEmpleado = response.PKEmpleado,
                                    Estado = 1
                                };
                                services.UpdateEstado(empleado);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Sucedió un error" + ex.Message);
                        }

                        MenuAdmin sistema = new MenuAdmin();
                        sistema.Show();
                        Close();
                    }
                    if (response.Puestos.Nombre == "Vendedor")
                    {
                        MenuVendedor sistema = new MenuVendedor();
                        sistema.Show();
                        Close();
                    }
                }
                else
                    MessageBox.Show("Cuenta no encontrada/existe");
            }
            else
                MessageBox.Show("Ingresa los datos");
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