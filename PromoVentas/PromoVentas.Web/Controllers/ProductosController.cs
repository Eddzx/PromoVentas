using PromoVenta.BL;
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
            var ProductosBL = new ProductosBL();
            var ListadeProductos = ProductosBL.ObtenerProductos();

            return View(ListadeProductos);
        }
    }
}