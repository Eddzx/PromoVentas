using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.web.Controllers
{

   

    public class ProductosController : Controller

    {
        ProductosBL _productosBL;
      CategoriasBL _categoriasBL;
        

        public ProductosController()
        {
            _productosBL = new ProductosBL();
            _categoriasBL = new CategoriasBL();
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
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =  new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoProducto);

        }
        [HttpPost]
        public ActionResult Crear(Producto Producto, HttpPostedFileBase imagen )
        {
            if(ModelState.IsValid)
            {
                if(Producto.CategoriaId == 0)
                {

                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(Producto);
                }
                if (imagen != null)

                {
                    Producto.UrlImagen = GuardarImagen(imagen);

                }
                _productosBL.GuardarProducto(Producto);
                return RedirectToAction("Index");
            }
            var Categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(Categorias, "Id", "Descripcion");

            return View(Producto);
        }
        public ActionResult Editar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }
        [HttpPost]
        public ActionResult editar(Producto Producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (Producto.CategoriaId == 0)
                {

                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(Producto);
                }

                _productosBL.GuardarProducto(Producto);
                return RedirectToAction("Index");
            }
            var Categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(Categorias, "Id", "Descripcion");

            return View(Producto);

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
        private string GuardarImagen(HttpPostedFileBase imagen)
        {

          string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
        imagen.SaveAs(path); 

    return "/Imagenes/" + imagen.FileName;
   }
  }
}
