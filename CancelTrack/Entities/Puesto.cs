using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancelTrack.Entities
{
    public class Puesto
    {
        [Key] public int PKPuesto { get; set; }
        public string Nombre { get; set; }
    }
}
