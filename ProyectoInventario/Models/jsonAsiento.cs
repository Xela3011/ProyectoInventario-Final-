using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoInventario.Models
{
    
    public class jsonAsiento
    {

        public string Descripcion { get; set; }
        public int Auxiliar { get; set; }
        public List<cuentaAsiento> Cuentas { get; set; }
    }
}