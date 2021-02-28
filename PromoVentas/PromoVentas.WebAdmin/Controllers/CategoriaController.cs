using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.Web.Controllers
{
    public class CategoriaController : Controller
    {
        Categorias _categoriasBL;

        public CategoriaController()
        {
            _categoriasBL = new Categorias();
        }
        // GET: Categoria
        public ActionResult Index()
        {

            var ListadeCategorias = _categoriasBL.ObtenerCategoria();

            return View(ListadeCategorias);
        }//crar categorias------------------------------------------------
        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();
            return View(nuevaCategoria);
        }
        [HttpPost]//para que habra las paginas
        public ActionResult Crear(Categoria producto)
        {
            _categoriasBL.GuardarCategoria(producto);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var producto = _categoriasBL.ObtenerCategoria(id);
            return View(producto);
        }
        [HttpPost]//para que habra las paginas
        public ActionResult Editar(Categoria producto)
        {
            _categoriasBL.ObtenerCategoria();
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var producto = _categoriasBL.ObtenerCategoria(id);
            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _categoriasBL.ObtenerCategoria(id);
            return View(producto);
        }

        [HttpPost]//para que habra las paginas
        public ActionResult Eliminar(Categoria producto)
        {
            _categoriasBL.EliminarCategoria(producto.Id);
            return RedirectToAction("Index");
        }

    }
}