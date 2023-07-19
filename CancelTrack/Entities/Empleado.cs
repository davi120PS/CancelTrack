using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancelTrack.Entities
{
    public class Empleado
    {
        [Key] public int PKEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Matricula { get; set; }
        public int Contraseña { get; set; }
        public string Puesto { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
    }
}
