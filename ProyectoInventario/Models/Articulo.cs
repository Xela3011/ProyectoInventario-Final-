using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoInventario.Models
{
    [Table("Articulo")]
    public class Articulo
    {

        [Key]
        public int id_articulo { get; set; }
        [DisplayName("Descripcion")]
        public string descripcion_articulo { get; set; }
        [DisplayName("Existencia")]

        [Range(1, Int32.MaxValue, ErrorMessage = "Existencia debe ser mayor o igual a 1")]
        public int existencia { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Tipo de Inventario debe ser mayor o igual a 1")]
        [DisplayName("Tipo de Inventario")]
        [ForeignKey("TipoInventario")]
        public int id_tipo_inventario { get; set; }
        public virtual TipoInventario TipoInventario { get; set; }
        [DisplayName("Costo Unitario")]
        public decimal costo_unitario { get; set; }
        [DisplayName("Estado")]
        public string estado { get; set; }

    }
}
