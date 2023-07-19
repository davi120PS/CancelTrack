using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancelTrack.Entities
{
    public class Proveedor
    {
        [Key] public int PKProveedor { get; set; }
        public string Nombre { get; set; }
        public int PrecioProveedor { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
    }
}
