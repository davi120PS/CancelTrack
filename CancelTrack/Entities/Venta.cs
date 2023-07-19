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
        [ForeignKey("Cliente")] public int FKCliente { get; set; }
        public Cliente? Cliente { get; set; }
        [ForeignKey("Empleado")] public int FKEmpleado { get; set; }
        public Empleado? Employee { get; set; }
        public int Total { get; set; }
    }
}
