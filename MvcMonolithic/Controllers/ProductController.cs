using Microsoft.AspNetCore.Mvc;

namespace MvcMonolithic.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
