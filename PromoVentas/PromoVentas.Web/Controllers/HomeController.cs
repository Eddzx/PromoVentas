﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromoVentas.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }
    }
}