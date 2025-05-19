using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using CrudApplication.Repositorios;
using System.Data;
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
            if (_FuncionarioRepositorio.CadastrarFuncionario(funcionario))
            {
                _FuncionarioRepositorio.CadastrarFuncionario(funcionario);
                TempData["Mensagem"] = "✅ Funcionário cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = "❌ Email já cadastrado.";
            return View();
         

        }

        public IActionResult EditarFuncionario(int id)
        {
            var funcionario = _FuncionarioRepositorio.ObterFuncionarioPorId(id);

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
                TempData["MensagemErro"] = "❌ ID do funcionário inválido.";
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (_FuncionarioRepositorio.AtualizarFuncionario(funcionario))
                    {
                        TempData["Mensagem"] = "✅ Funcionário atualizado com sucesso!";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception)
                {
                    TempData["MensagemErro"] = "❌ Ocorreu um erro ao editar.";
                    return View(funcionario);
                }
            }
            return View(funcionario);
        }

        public IActionResult ExcluirFuncionario(int id)
        {
            _FuncionarioRepositorio.ExcluirFuncionario(id);
            TempData["Mensagem"] = "⚠️ Funcionário excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var funcionario = _FuncionarioRepositorio.ObterFuncionarioPorEmail(email);
            if (funcionario != null && funcionario.Senha == senha)
            {
                HttpContext.Session.SetString("emailUsuario", funcionario.Email);
                TempData["Mensagem"] = $"🔓 Bem-vindo(a), {funcionario.Email}!";
                return RedirectToAction("Index", "Menu");
            }

            ViewBag.Erro = "❌ Email ou senha inválidos.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Mensagem"] = "👋 Logout realizado com sucesso!";
            return RedirectToAction("Login", "Funcionario");
        }
    }
}