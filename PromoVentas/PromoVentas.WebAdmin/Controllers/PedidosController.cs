using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.WebAdmin.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Cliente
        PedidosBL _pedidosBL;
        
        public PedidosController()
        {
            _pedidosBL = new PedidosBL();
        }

        public ActionResult Index()
        {
            var listadePedidos = _pedidosBL.ObtenerPedidos();
            return View(listadePedidos);
        }
    }
}//no se han creado las demas vistas de elimar detalles etc, solo la vista INDEX--------------------------------------------------------