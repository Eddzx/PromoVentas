using System.Web.Mvc;

namespace PromoVentas.web.Controllers
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