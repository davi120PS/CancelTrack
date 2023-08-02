using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancelTrack.Entities
{
    public class Venta
    {
        [Key] public int PKVenta { get; set; }
        [ForeignKey("Clientes")] public int? FKCliente { get; set; }
        public Cliente Clientes { get; set; }
        [ForeignKey("Empleados")] public int? FKEmpleado { get; set; }
        public Empleado Empleados { get; set; }
        public List<Producto> Productos { get; set; }
        public ICollection<VentaProducto> VentaProductos { get; set; }
        private int total;
        public int Total
        {
            get { return total; }
            set { total += value; }
        }
        public Venta()
        {
            VentaProductos = new List<VentaProducto>();
        }
    }
}