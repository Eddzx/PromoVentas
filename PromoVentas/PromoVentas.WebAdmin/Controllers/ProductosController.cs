using PromoVenta.BL;
using PromoVentas.WebAdmin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.WebAdmin.Controllers
{
    public class ProductosController : Controller

    {
        ProductosBL _productosBL;

        public ProductosController()
        {
            _productosBL = new ProductosBL();
        }
        // GET: Productos
        public ActionResult Index()
        {
            var listadeProductos = _productosBL.ObtenerProductos();

            return View(listadeProductos);
        }


        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();

            return View(nuevoProducto);

        }
        [HttpPost]
        public ActionResult Crear(Producto Producto)
        {
            _productosBL.GuardarProducto(Producto);
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);

            return View(producto);
        }
        [HttpPost]
        public ActionResult editar(Producto Producto)
        {
            _productosBL.GuardarProducto(Producto);
            return RedirectToAction("Index");      
                
         }
        public ActionResult Detalle(int id)
        {
            var Producto = _productosBL.ObtenerProducto(id);

            return View(Producto);
        }

        public ActionResult Eliminar(int id)
        {
            var Producto = _productosBL.ObtenerProducto(id);

            return View(Producto);
        }
        [HttpPost]
        public ActionResult Eliminar(Producto Producto)
        {
            _productosBL.EliminarProducto(Producto.Id);

            return RedirectToAction("Index");
        }

    }
}