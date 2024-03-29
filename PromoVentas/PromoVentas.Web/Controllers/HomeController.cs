﻿using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productosBL = new ProductosBL();
            var ListadeProductos = productosBL.ObtenerProductos();

            ViewBag.adminWebsiteUrl = 
                ConfigurationManager.AppSettings ["adminWebsiteUrl"];

            return View(ListadeProductos);

        }
    }
}