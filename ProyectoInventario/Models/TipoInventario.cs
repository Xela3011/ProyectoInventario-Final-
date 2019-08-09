
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoInventario.Models
{
    [Table("tipo_inventario")]
    public class TipoInventario
    {

        [Key]

        public int id_tipo_inventario { get; set; }
        [DisplayName("Descripcion Tipo Inventario")]
        public string descripcion_tipo { get; set; }
        [DisplayName("Cuenta Contable")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Cuenta Contable debe ser mayor o igual a 1")]
        public string cuenta_contable { get; set; }
        [DisplayName("Estado")]
        public string estado { get; set; }

    }
}
