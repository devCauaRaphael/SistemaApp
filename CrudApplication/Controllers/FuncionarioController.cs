using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class FuncionarioController : Controller
    {
        FuncionarioRepositorio _FuncionarioRepositorio;

        public FuncionarioController(FuncionarioRepositorio funcionarioRepositorio)
        {
            _FuncionarioRepositorio = funcionarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
