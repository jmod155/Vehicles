using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Api.Helpers;
using Vehicles.Api.Models;

namespace Vehicles.Api.Controllers
{
    public class AccountController: Controller
    {
        private readonly IUserHelper _userHelper;

        //se inyecta el constructor
        public AccountController(IUserHelper userHelper)
        {
             _userHelper = userHelper;
        }
        //metodo de loguin

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)//si el usuario esta autenticado se redirecciona al index del home
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(new LoginViewModel());
        }
        [HttpPost]//metodo cuando se da clic al boton submot
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) //se valida que cumpla las condiciones que se delararon en LoginViewModel
            {  //
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");//si se logueo se envia al index
                }

                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
            }

            return View(model); //si no cumple las condiciones
        }
        //metodo de deslogueo
        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
