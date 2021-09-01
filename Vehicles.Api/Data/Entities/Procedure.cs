using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.Api.Data.Entities
{
    public class Procedure
    {
        public int Id { get; set; }

        [Display(Name = "Procedimiento")]//nombre que va a ver el usuario
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracteres")]//maximo del campo y error en caso de sobrepasar el tamaño
        [Required(ErrorMessage = "El campo {0} es Obligatorio")] //DataAnnotations para hacer el campo requerido(ErrorMessage = mensaje personalizado)
        public string Description { get; set; }//campo
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }

    }
}
