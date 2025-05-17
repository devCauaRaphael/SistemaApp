using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
