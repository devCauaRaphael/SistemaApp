using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class ProdutoController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
