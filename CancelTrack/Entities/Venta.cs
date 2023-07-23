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
        [ForeignKey("VentaProductos")] public int? FKVentaProducto { get; set; }
        public VentaProducto VentaProductos { get; set; }
        public int Total { get; set; }
    }
}
