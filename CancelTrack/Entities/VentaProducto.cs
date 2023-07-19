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
        [ForeignKey("Venta")] public int FKVenta { get; set; }
        public Venta? Venta { get; set; }
        [ForeignKey("Cliente")] public int FKProducto { get; set; }
        public Cliente? Cliente { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
