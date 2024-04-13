using Microsoft.AspNetCore.Mvc;
using ProjEmprestimo.GerenciaArquivo;
using ProjEmprestimo.Models;
using ProjEmprestimo.Repository.Contract;

namespace ProjEmprestimo.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepository _livroRepository;
        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IActionResult Index() 
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(Livro livro, IFormFile file)
        {
            var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);
            livro.imgLivro = Caminho;
            _livroRepository.Cadastrar(livro);
            ViewBag.msg = "Cadastro realizado!!";
            return View();
        }
      
    }
}
