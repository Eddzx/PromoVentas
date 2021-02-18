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