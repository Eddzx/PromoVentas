using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        SeguridadBL _seguridadBL;

        public LoginController()
        {
            _seguridadBL = new SeguridadBL();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection Data)
        {
            var nombreUsuario = Data["username"];
            var contrasena = Data["password"];

            var usuarioValido = _seguridadBL
                .Autorizar(nombreUsuario, contrasena);

            if (usuarioValido)
            {
              return RedirectToAction("Index","Home");
            }

            ModelState.AddModelError("", "Usuario o contraseña invalido");

            return View();
            
        }

  }
}