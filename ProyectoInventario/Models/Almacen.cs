using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoInventario.Models
{
    [Table("almacen")]
    public class Almacen
    {

        [Key]
        [Required]
        public int id_almacen { get; set; }
        [DisplayName("Descripcion")]
        [Required]
        public string descripcion_almacen { get; set; }
        [DisplayName("Estado")]
        [Required]
        public string estado { get; set; }

    }

    public enum Estado
    {
        Activo,
        Inactivo
    }
}