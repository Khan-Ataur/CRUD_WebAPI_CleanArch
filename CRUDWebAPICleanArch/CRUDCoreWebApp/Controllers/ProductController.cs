using Microsoft.AspNetCore.Mvc;

namespace CRUDCoreWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
