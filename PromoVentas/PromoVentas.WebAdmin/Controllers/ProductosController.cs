﻿using PromoVenta.BL;
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
            var producto = _productosBL.ObtenerProductos(id);

            return View(producto);
        }
        [HttpPost]
        public ActionResult editar(Producto Producto)
        {
            _productosBL.GuardarProducto(Producto);
            return RedirectToAction("Index");      
                
         }
    }

}