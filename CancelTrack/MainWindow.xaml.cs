using CancelTrack.Interfaces;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VistaVendedor interfaz = new VistaVendedor();
            interfaz.Show();
            Close();
        }
        UserServices services = new UserServices();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUserName.Text;
            string pass = txtPassword.Password;
            //Usuarios response = services.Login(user, pass);
            var response = services.Login(user, pass);

            if (txtUserName.Text != "" && txtPassword.Password != "")
            {
                if (response != null)
                {
                    if (response.Roles.Name == "SA")
                    {
                        VistaVendedor sistema = new VistaVendedor();
                        sistema.Show();
                        Close();
                    }

                    if (response.Roles.Name == "Admin")
                    {
                        VistaAdmin sistema = new VistaAdmin();
                        sistema.Show();
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingresa los datos");
            }
        }
    }
}
