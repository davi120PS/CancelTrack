﻿using CancelTrack.Entities;
using CancelTrack.InterfazVendedor;
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
    /// Lógica de interacción para CRUDCliente.xaml
    /// </summary>
    public partial class CRUDCliente : Window
    {
        public CRUDCliente()
        {
            InitializeComponent();
            GetClientesTable();
        }
        ClienteServices services = new ClienteServices();
        private void BtnAddCli_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKCliente.Text == "")
            {
                if (txtNombreCli.Text != "" && txtApellidoCli.Text != "" && txtDireccionCli.Text != "" && txtTelefonoCli.Text != "" && txtCorreoCli.Text != "")
                {
                    Cliente usuario = new Cliente()
                    {
                        Nombre = txtNombreCli.Text,
                        Apellido = txtApellidoCli.Text,
                        Direccion = txtDireccionCli.Text,
                        Telefono = int.Parse(txtTelefonoCli.Text),
                        Correo = txtCorreoCli.Text
                    };

                    services.Add(usuario);
                    MessageBox.Show("Cliente registrado");
                    GetClientesTable();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show("Faltan datos por llenar");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKCliente.Text);
                Cliente usuario = new Cliente()
                {
                    PKCliente = Id,
                    Nombre = txtNombreCli.Text,
                    Apellido = txtApellidoCli.Text,
                    Direccion = txtDireccionCli.Text,
                    Telefono = int.Parse(txtTelefonoCli.Text),
                    Correo = txtCorreoCli.Text
                };
                MessageBox.Show("Cliente actualizado");
                services.Update(usuario);
            }
            GetClientesTable();
            LimpiarCampos();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKCliente.Text == "")
            {
                MessageBox.Show("Selecciona un cliente");
            }
            else
            {
                int Id = Convert.ToInt32(txtPKCliente.Text);
                Cliente usuario = new Cliente();
                usuario.PKCliente = Id;
                services.Delete(Id);
                MessageBox.Show("Cliente Eliminado");
                GetClientesTable();
                LimpiarCampos();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente = (sender as FrameworkElement).DataContext as Cliente;

            txtPKCliente.Text = cliente.PKCliente.ToString();
            txtNombreCli.Text = cliente.Nombre.ToString();
            txtApellidoCli.Text = cliente.Apellido.ToString();
            txtDireccionCli.Text = cliente.Direccion.ToString();
            txtTelefonoCli.Text = cliente.Telefono.ToString();
            txtCorreoCli.Text = cliente.Correo.ToString();
        }
        public void GetClientesTable()
        {
            TablaCliente.ItemsSource = services.GetClientes();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin admin = new MenuAdmin();
            admin.Show();
            Close();
        }
        public void LimpiarCampos()
        {
            txtPKCliente.Clear();
            txtNombreCli.Clear();
            txtApellidoCli.Clear();
            txtDireccionCli.Clear();
            txtTelefonoCli.Clear();
            txtCorreoCli.Clear();
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtPKCliente.Clear();
            txtNombreCli.Clear();
            txtApellidoCli.Clear();
            txtDireccionCli.Clear();
            txtTelefonoCli.Clear();
            txtCorreoCli.Clear();
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