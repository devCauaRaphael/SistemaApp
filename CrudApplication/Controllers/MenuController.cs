using CrudApplication.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    public class MenuController : Controller
    {
        FuncionarioRepositorio _FuncionarioRepositorio;
        public MenuController(FuncionarioRepositorio funcionarioRepositorio)
        {
            _FuncionarioRepositorio = funcionarioRepositorio;
        }

        public IActionResult Index()
        {
            var email = HttpContext.Session.GetString("emailUsuario");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Funcionario"); // redireciona se não estiver logado
            }

            var funcionario = _FuncionarioRepositorio.ObterFuncionarioPorEmail(email);

            if (funcionario == null)
            {
                return RedirectToAction("Login", "Funcionario");
            }

            return View(funcionario); // Passa o funcionário pra View
        }
    }
}