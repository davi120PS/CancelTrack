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
            MenuAdmin sistema = new MenuAdmin();
            sistema.Show();
            Close();/*
            string user = txtUserName.Text;
            string pass = txtPassword.Password;
            //Usuarios response = services.Login(user, pass);
            var response = services.Login(user, pass);

            if (txtUserName.Text != "" && txtPassword.Password != "")
            {
                if (response != null)
                {
                    if (response.Puestos.Nombre == "Admin")
                    {
                        MenuAdmin sistema = new MenuAdmin();
                        sistema.Show();
                        Close();
                    }
                    if (response.Puestos.Nombre == "Vendedor")
                    {
                        VistaVendedor sistema = new VistaVendedor();
                        sistema.Show();
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingresa los datos");
            }*/
        }
    }
}