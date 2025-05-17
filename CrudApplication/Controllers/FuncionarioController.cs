using CrudApplication.Models;
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
            return View(_FuncionarioRepositorio.TodosFuncionarios());
        }
        public IActionResult CadastrarFuncionario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarFuncionario(tbFuncionario funcionario)
        {
            _FuncionarioRepositorio.CadastrarFuncionario(funcionario);
            return RedirectToAction(nameof(Index));
        }
    }
}
