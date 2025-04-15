using LOGIN_MVC_ASD.DAL;
using LOGIN_MVC_ASD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LOGIN_MVC_ASD.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioDAL dal = new UsuarioDAL();
                Usuario usuario = dal.GetUsuarioLogin(model.Username, model.Password);  

                //Validar usuario
                if (usuario != null)
                {
                    HttpContext.Session.SetString("Username", model.Username);
                    //Autenticación exitosa
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            }
            return View(model); 
        }
    }
}
