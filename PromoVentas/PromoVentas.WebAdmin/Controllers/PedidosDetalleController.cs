using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.WebAdmin.Controllers
{
    public class PedidoDetalleController : Controller
    {
        PedidosBL _PedidoBL;
        ProductosBL _ProductosBL;
        public PedidoDetalleController()
        {
            _PedidoBL = new PedidosBL();
            _ProductosBL = new ProductosBL();


        }
        // GET: PedidosDetalle
        public ActionResult Index(int id)
        {
            var pedido = _PedidoBL.ObtenerPedido(id);
            return View(pedido);
        }
        public ActionResult Crear(int id)
        {
            var NuevoPedidoDetalle = new PedidoDetalle();
            NuevoPedidoDetalle.PedidoId = id;
            var Productos = _ProductosBL.ObtenerProductos();

            ViewBag.productoId = new SelectList(Productos, "Id", "Descripcion");
            return View(NuevoPedidoDetalle);
        }
        [HttpPost]
        public ActionResult Crear (PedidoDetalle  pedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                if (pedidoDetalle.ProductoId== 0)
                {
                    ModelState.AddModelError("ProductoId", "Seleccione un producto");
                    return View(pedidoDetalle);
                }
                _PedidoBL.GuardarPedidoDetalle(pedidoDetalle);
                return RedirectToAction("Index");
            }
            var productos = _ProductosBL.ObtenerProductos();
            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");
            return View(pedidoDetalle);
        }
    }
}