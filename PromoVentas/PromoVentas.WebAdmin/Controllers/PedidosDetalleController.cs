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
            pedido.ListaPedidoDetalle = _PedidoBL.ObtenerPedidoDetalle(id);

            return View(pedido);
        }

        public ActionResult Crear(int id)
        {
            var NuevoPedidoDetalle = new PedidoDetalle();
            NuevoPedidoDetalle.PedidoId = id;

            var Productos = _ProductosBL.ObtenerProductosActivos();
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

                return RedirectToAction("Index", new { Id = pedidoDetalle.PedidoId });
            }
            var productos = _ProductosBL.ObtenerProductosActivos();
            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");

            return View(pedidoDetalle);
        }

        public ActionResult Eliminar(int Id)
        {
            var pedidoDetalle = _PedidoBL.ObtenerPedidoDetallePorId(Id);

            return View(pedidoDetalle);
        }

        [HttpPost]
        public ActionResult Eliminar(PedidoDetalle pedidoDetalle)
        {
            _PedidoBL.EliminarPedidoDetalle(pedidoDetalle.Id);

            return RedirectToAction("Index", new { Id = pedidoDetalle.PedidoId });
        }
    }
}