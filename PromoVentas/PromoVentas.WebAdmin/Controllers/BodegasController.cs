using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.WebAdmin.Controllers
{
   public class BodegasController : Controller
    {
        BodegasBL _bodegasBL;

        public BodegasController()
        {
            _bodegasBL = new PromoVenta.BL.BodegasBL();
        }
        // GET: Bodegas
        public ActionResult Index()
        {

            var ListadeBodegass = _bodegasBL.ObtenerBodegas();

            return View(ListadeBodegass);
        }//-------------------------------------------crar bodegas------------------------------------------------
        public ActionResult Crear()
        {
            var nuevaBodegas = new Bodega();
            return View(nuevaBodegas);
        }
        [HttpPost]//para que habra las paginas
        public ActionResult Crear(Bodega bodega)

        {
            if (ModelState.IsValid)
            {
                if (bodega.Descripcion != bodega.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacios al inicio o al final");
                    return View(bodega);
                }
                _bodegasBL.GuardarBodega(bodega);
                return RedirectToAction("Index");
            }
            return View(bodega);
        }

        public ActionResult Editar(int id)
        {
            var producto = _bodegasBL.ObtenerBodega(id);
            return View(producto);
        }
        [HttpPost]//-------------------------------------------ediatr--------------------------------------------
        public ActionResult Editar(Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                if (bodega.Descripcion != bodega.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacios al inicio o al final");
                    return View(bodega);
                }
                _bodegasBL.GuardarBodega(bodega);
                return RedirectToAction("Index");
            }
            return View(bodega);
        }

        public ActionResult Detalle(int id)
        {
            var producto = _bodegasBL.ObtenerBodega(id);
            return View(producto);
        }
        //-------------------------------------------detalle-------------------------------------------
        public ActionResult Eliminar(int id)
        {
            var producto = _bodegasBL.ObtenerBodega(id);
            return View(producto);
        }
        //-------------------------------------------eliminar-------------------------------------------
        [HttpPost]//para que habra las paginas
        public ActionResult Eliminar(Bodega producto)
        {
            _bodegasBL.EliminarBodega(producto.Id);
            return RedirectToAction("Index");
        }
    }
}