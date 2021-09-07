using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Api.Data.Entities;

namespace Vehicles.Api.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email); //metodo que se le pasa el email y retorna el usuario
        Task<IdentityResult> AddUserAsync(User user, string password); //se pasa el usuario y el password y lo crea
        Task CheckRoleAsync(string roleName);//para crear rol

        Task AddUserToRoleAsync(User user, string roleName);//se pasa el usuario y el rol y agrega la relacion entre usuario y rol

        Task<bool> IsUserInRoleAsync(User user, string roleName);//para saber si existe o no en el rol

    }
}
