using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Matricula { get; set; }
        public string Contraseña { get; set; }
        [ForeignKey("Puesto")] public int? FKPuesto { get; set; }//El signo de interrogacion en "int?" dice que puede o no llevar un valor
        public Puesto Puestos { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
    }
}
