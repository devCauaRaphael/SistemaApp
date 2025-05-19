using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using CrudApplication.Repositorios;
namespace CrudApplication.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositorio _ProdutoRepositorio;

        public ProdutoController(ProdutoRepositorio produtoRepositorio)
        {
            _ProdutoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            return View(_ProdutoRepositorio.TodosProdutos());
        }

        public IActionResult CadastrarProduto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarProduto(tbProduto produto)
        {
            _ProdutoRepositorio.CadastrarProduto(produto);
            TempData["Mensagem"] = "✅ Produto cadastrado com sucesso!";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditarProduto(int id)
        {
            var produto = _ProdutoRepositorio.ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarProduto(int id, [Bind("IdProduto, NomeProduto,Descricao,Preco,Quantidade")] tbProduto produto)
        {
            ModelState.Clear();
            if (id != produto.IdProduto)
            {
                TempData["MensagemErro"] = "❌ ID do produto inválido.";
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (_ProdutoRepositorio.AtualizarProduto(produto))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception)
                {
                    TempData["MensagemErro"] = "❌ Ocorreu um erro ao editar."; 
                    return View(produto);
                }
            }
            return View(produto);
        }
        public IActionResult ExcluirProduto(int id)
        {
            _ProdutoRepositorio.ExcluirProduto(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
