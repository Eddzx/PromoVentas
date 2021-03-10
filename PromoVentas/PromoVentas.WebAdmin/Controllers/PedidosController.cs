using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.WebAdmin.Controllers
{
    public class PedidosController : Controller
    {    // GET: Cliente
        PedidosBL _pedidosBL;
        ClientesBL _clientesBL;
        
        public PedidosController()
        {
            _pedidosBL = new PedidosBL();

            _clientesBL = new ClientesBL();
        }

        public ActionResult Index()
        {
            var listadePedidos = _pedidosBL.ObtenerPedidos();

            return View(listadePedidos);
        }

        public ActionResult Crear()
        {
            var nuevoPedido = new Pedido();
            var clientes = _clientesBL.ObtenerClientes();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre");

            return View(nuevoPedido);
        }

        [HttpPost]
        public ActionResult Crear(Pedido pedido)
        {
         if (ModelState.IsValid)
            {
                if (pedido.ClienteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(pedido); 
                }

                _pedidosBL.GuardarPedido(pedido);

                return RedirectToAction("Index");
            }

            var clientes = _clientesBL.ObtenerClientes();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre");

            return View(pedido);
        }

        public ActionResult Editar(int id)
        {
            var pedido = _pedidosBL.ObtenerPedidos(id);
            var clientes = _clientesBL.ObtenerClientes();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre", pedido.ClienteId);

            return View(pedido);
        }

        [HttpPost]
        public ActionResult Editar(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                if (pedido.ClienteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(pedido);
                }

                _pedidosBL.GuardarPedido(pedido);

                return RedirectToAction("Index");
            }

            var clientes = _clientesBL.ObtenerClientes();

            ViewBag.ClienteId = new SelectList(clientes, "Id", "Nombre");

            return View(pedido);
        }

        public ActionResult Detalle(int id)
        {
            var pedido = _pedidosBL.ObtenerPedidos(id);

            return View(pedido);
        }
    }
}  