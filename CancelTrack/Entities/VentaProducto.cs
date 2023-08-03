using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancelTrack.Entities
{
    public class VentaProducto
    {
        [Key] public int PKVentaProducto { get; set; }
        [ForeignKey("Ventas")] public int FKVentas { get; set; }
        public Venta Ventas { get; set; }
        [ForeignKey("Productos")] public int FKProducto { get; set; }
        public Producto Productos { get; set; }
        public int Cantidad { get; set; }
    }
}