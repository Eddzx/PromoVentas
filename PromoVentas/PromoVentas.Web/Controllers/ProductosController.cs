using PromoVentas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.Web.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {

            var producto = new ProductoModel();
            producto.Id = 1;
            producto.Descripcion = " Fardo de Maseca"; 

            return View(producto);
        }
    }
}