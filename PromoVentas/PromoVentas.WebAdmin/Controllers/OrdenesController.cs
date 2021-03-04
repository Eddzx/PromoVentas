using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.WebAdmin.Controllers
{
    public class OrdenesController : Controller
    {
        // GET: Cliente
        OrdenesBL _ordenesBL;
        
        public OrdenesController()
        {
            _ordenesBL = new OrdenesBL();
        }

        public ActionResult Index()
        {
            var listadeOrdenes = _ordenesBL.ObtenerOrdenes();
            return View(listadeOrdenes);
        }
    }
}//no se han creado las demas vistas de elimar detalles etc, solo la vista INDEX--------------------------------------------------------