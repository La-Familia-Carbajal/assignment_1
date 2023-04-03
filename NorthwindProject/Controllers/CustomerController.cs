using Microsoft.AspNetCore.Mvc;

namespace NorthwindProject.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
