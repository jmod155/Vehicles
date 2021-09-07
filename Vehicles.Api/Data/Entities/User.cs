using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Common.Enums;

namespace Vehicles.Api.Data.Entities
{
    public class User: IdentityUser
    {
        [Display(Name = "Nombres")]//nombre que va a ver el usuario
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracteres")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")] //DataAnnotations para hacer el campo requerido(ErrorMessage = mensaje personalizado)
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]//nombre que va a ver el usuario
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracteres")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")] //DataAnnotations para hacer el campo requerido(ErrorMessage = mensaje personalizado)
        public string LastName { get; set; }

        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DocumentType DocumentType { get; set; }

        [Display(Name = "Documento")]//nombre que va a ver el usuario
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} Caracteres")]
        [Required(ErrorMessage = "El campo {0} es Obligatorio")] //DataAnnotations para hacer el campo requerido(ErrorMessage = mensaje personalizado)
        public string Document { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string Address { get; set; }

        //foto del usuario de tipo guid = clave alfa numnerica que no se repite
        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO :primera imagen
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44354/images/noimage.png"  
            : $"https://vehicleszulu.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Tipo de Usuario")]
        public UserType UserType { get; set; }//enum del proyecto DataAnnotations

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";//concatenacion del los nombres de los usuarios



    }
}
