using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.Api.Data.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Documento")]//nombre que va a ver el usuario
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracteres")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")] //DataAnnotations para hacer el campo requerido(ErrorMessage = mensaje personalizado)
        public string Description { get; set; }
    }
}
