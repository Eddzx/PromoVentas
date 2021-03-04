using PromoVenta.BL;
using PromoVentas.WebAdmin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.WebAdmin.Controllers
{
    public class ClientesController : Controller
    {
        PromoVenta.BL.ClientesBL _clientesBL;

        public ClientesController()
        {
            _clientesBL = new PromoVenta.BL.ClientesBL();
        }
        // GET: Clientes
        public ActionResult Index()
        {
            var ListaClientes = _clientesBL.ObtenerClientes();

            return View(ListaClientes);
        }

        //-------------------------------------------crar clientes------------------------------------------------
        public ActionResult Crear()
        {
            var nuevaCategoria = new Clientes();
            return View(nuevaCategoria);
        }
        [HttpPost]//para que habra las paginas
        public ActionResult Crear(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                if (clientes.NombreCliente != clientes.NombreCliente.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacios al inicio o al final");
                    return View(clientes);
                }
                _clientesBL.GuardarClientes(clientes);
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        public ActionResult Editar(int id)
        {
            var producto = _clientesBL.ObtenerClientes(id);
            return View(producto);
        }
        [HttpPost]//-------------------------------------------ediatr--------------------------------------------
        public ActionResult Editar(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                if (clientes.NombreCliente != clientes.NombreCliente.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacios al inicio o al final");
                    return View(clientes);
                }
                _clientesBL.GuardarClientes(clientes);
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        public ActionResult Detalle(int id)
        {
            var producto = _clientesBL.ObtenerClientes(id);
            return View(producto);
        }
        //-------------------------------------------detalle-------------------------------------------
        public ActionResult Eliminar(int id)
        {
            var producto = _clientesBL.ObtenerClientes(id);
            return View(producto);
        }
        //-------------------------------------------eliminar-------------------------------------------
        [HttpPost]//para que habra las paginas
        public ActionResult Eliminar(Clientes producto)
        {
            _clientesBL.EliminarCategoria(producto.Id);
            return RedirectToAction("Index");
        }

    }
}