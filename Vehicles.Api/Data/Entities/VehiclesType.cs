using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.Api.Data.Entities
{
    public class VehiclesType
    {//propieddes de la clase
        public int Id { get; set; }

        [Display(Name="Tipo de Vehículo")]//nombre que va a ver el usuario
        [MaxLength(50,ErrorMessage ="El campo {0} no puede tener mas de {1} Caracteres")]//maximo del campo y error en caso de sobrepasar el tamaño
        [Required (ErrorMessage="El campo {0} es Obligatorio")] //DataAnnotations para hacer el campo requerido(ErrorMessage = mensaje personalizado)
        public string Description { get; set; }
    }
}
