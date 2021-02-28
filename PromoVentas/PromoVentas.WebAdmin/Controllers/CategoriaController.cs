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
        CategoriaBL _categoriasBL;

        public CategoriaController()
        {
            _categoriasBL = new CategoriaBL();
        }
        // GET: Categoria
        public ActionResult Index()
        {

            var ListadeCategorias = _categoriasBL.ObtenerCategorias();

            return View(ListadeCategorias);
        }//crar categorias------------------------------------------------
        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();
            return View(nuevaCategoria);
        }
        [HttpPost]//para que habra las paginas
        public ActionResult Crear(Categoria categoria)
      
        {
            if(ModelState.IsValid)
            {
                if(categoria.Descripcion !=categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacios al inicio o al final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Editar(int id)
        {
            var producto = _categoriasBL.ObtenerCategoria(id);
            return View(producto);
        }
        [HttpPost]//para que habra las paginas
        public ActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacios al inicio o al final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
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