﻿using CancelTrack.Services;
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
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        public Producto()
        {
            InitializeComponent();
            GetProductoTable();
        }
        EmpleadoServices services = new EmpleadoServices();
        private void UserTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void GetProductoTable()
        {
            //UserTable.ItemsSource = services.GetProducto();
        }
    }
}
