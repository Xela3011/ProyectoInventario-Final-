using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoInventario.Models
{
    [Table("transaccion")]
    public class Transaccion
    {

        [Key]
        public int id_transaccion { get; set; }
        [Required]
        [DisplayName("Tipo de Transaccion")]
        public string tipo_transaccion { get; set; }
        [DisplayName("ID Articulo")]
        [ForeignKey("Articulo")]
        public int id_articulo { get; set; }
        public virtual Articulo Articulo { get; set; }
        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }
        [DisplayName("Cantidad")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Cantidad debe ser mayor o igual a 1")]
        public int cantidad { get; set; }
        [DisplayName("Monto")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Monto debe ser mayor o igual a 1")]
        public decimal monto { get; set; }

    }

    public enum tipoTransaccion
    {
        Entrada,
        Salida,
        Traslado,
        Ajuste
    }
}
