using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
