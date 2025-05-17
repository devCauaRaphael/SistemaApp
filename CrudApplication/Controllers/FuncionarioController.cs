using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using CrudApplication.Repositorios;
namespace CrudApplication.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioRepositorio _FuncionarioRepositorio;

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
        public IActionResult EditarFuncionario(int id)
        {
            var funcionario = _FuncionarioRepositorio.ObterFuncionario(id);

            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarFuncionario(int id, [Bind("IdFuncionario, Nome,Email,Senha")] tbFuncionario funcionario)
        {
            ModelState.Clear();
            if (id != funcionario.IdFuncionario)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (_FuncionarioRepositorio.AtualizarFuncionario(funcionario))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao Editar.");
                    return View(funcionario);
                }
            }
            return View(funcionario);
        }
        public IActionResult ExcluirFuncionario(int id)
        {
            _FuncionarioRepositorio.ExcluirFuncionario(id);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Login()
        {
             return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var funcionario = _FuncionarioRepositorio.ObterFuncionario(email);
            if (funcionario != null && funcionario.Senha == senha)
            {
                return RedirectToAction("Index", "Menu");
            }
            return View(funcionario);
        }
        
    }
}
