using System.Web.Mvc;

namespace PromoVentas.web.Controllers
{
    //========================================= agregando autorizacion ==========================================
    [Authorize]

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}