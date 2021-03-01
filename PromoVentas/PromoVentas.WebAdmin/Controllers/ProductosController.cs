using PromoVenta.BL;
using System.Web.Mvc;
using System.Collections;
using System.Web;
using System;

namespace PromoVentas.WebAdmin.Controllers
{
    public class ProductosController : Controller

    {
        ProductosBL _productosBL;
      CategoriasBL _CategoriasBL;
        private IEnumerable Categorias;

        public ProductosController()
        {
            _productosBL = new ProductosBL();
            _CategoriasBL = new CategoriasBL();
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
            var Categoria = _CategoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias =  new SelectList(Categorias, "Id", "Descripcion");

            return View(nuevoProducto);

        }
        [HttpPost]
        public ActionResult Crear(Producto Producto, HttpPostedFile imagen)
        {
            if(ModelState.IsValid)
            {
                if(Producto.CategoriaId ==0)
                {

                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(Producto);
                }

                if(imagen != null ) 
                 {
                    Producto.UrlImagen = GuardarImagen(imagen);     
                 }


                _productosBL.GuardarProducto(Producto);
                return RedirectToAction("Index");
            }
            var Categoria = _CategoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias = new SelectList(Categorias, "Id", "Descripcion");

            return View(Producto);
        }

        private string GuardarImagen(HttpPostedFile imagen)
        {
            throw new NotImplementedException();
        }

        public ActionResult Editar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            var Categoria = _CategoriasBL.ObtenerCategorias();

            ViewBag.categoriaId = new SelectList(Categorias, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }
        [HttpPost]
        public ActionResult editar(Producto Producto)
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
            var Categoria = _CategoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias = new SelectList(Categorias, "Id", "Descripcion");

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