using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoInventario.Models
{
    public class cuentaAsiento
    {
        public int id { get; set; }
        public string cuenta { get; set; }
        public string tipo { get; set; }
        public decimal monto { get; set; }
    }
}