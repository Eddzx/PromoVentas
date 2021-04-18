using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            //============================== a gregando la ========================
            FormsAuthentication.SignOut();
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
                //====================================== agregando control de las cookis al navegador-==============
                FormsAuthentication.SetAuthCookie(nombreUsuario, true);

              return RedirectToAction("Index","Home");
            }

            ModelState.AddModelError("", "Usuario o contraseña no valido");

            return View();
            
        }

  }
}