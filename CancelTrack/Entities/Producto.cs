﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancelTrack.Entities
{
    public class Producto
    {
        [Key] public int PKProducto { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("Proveedor")] public int FKProveedor { get; set; }
        public Proveedor Proveedor { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int CantidadInventario { get; set; }
    }
}
