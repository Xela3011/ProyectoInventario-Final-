using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoInventario.Models
{
    public class asientoModel
    {
        [Required]
        [Display(Name = "Descripción Asiento"), StringLength(100, MinimumLength = 1)]
        [RegularExpression("[a-zA-Z0-9 áéíóúñÁÉÍÓÚÑ]+$", ErrorMessage = "Este campo solo acepta letras y números")]
        public string descripcionAsiento { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Desde")]
        public DateTime fechaDesde { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Hasta")]
        public DateTime fechaHasta { get; set; }

        public string ErrorMessage  { get; set; }
    }
}