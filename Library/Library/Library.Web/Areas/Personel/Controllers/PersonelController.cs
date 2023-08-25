using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Personel.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
