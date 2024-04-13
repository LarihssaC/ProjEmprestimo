using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.AspNetCore.Mvc;
using ProjEmprestimo.CarrinhoCompra;
using ProjEmprestimo.Models;
using ProjEmprestimo.Repository.Contract;
using System.Diagnostics;

namespace ProjEmprestimo.Controllers
{
    public class HomeController : Controller
    {
        private ILivroRepository _livrorepository;
        private CookieCarrinhoCompra _cookiecarrinhocompra;
        private IEmprestimoRepository _emprestimorepository;
        private IItemRepository _itemRepository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILivroRepository livrorepository,
                              CookieCarrinhoCompra cookiecarrinhocompra,
                              IEmprestimoRepository emprestimorepository,
                              IItemRepository itemRepository)
        {
            _livrorepository = livrorepository;
            _cookiecarrinhocompra = cookiecarrinhocompra;
            _emprestimorepository = emprestimorepository;
            _itemRepository = itemRepository;
        }

        public IActionResult AdicionarItem(int id)
        {
            Livro produto = _livrorepository.ObterLivros(id);
            if(produto == null)
            {
                return View("NaoExisteItem");
            }
            else
            {
                var item = new Livro()
                {
                    codLivro = id,
                    quantidade = 1,
                    imgLivro = produto.imgLivro,
                    nomeLivro = produto.nomeLivro
                };
                _cookiecarrinhocompra.Cadastrar(item);
                return RedirectToAction(nameof(Carrinho));
            }
        }

        public IActionResult Carrinho()
        {
            return View(_cookiecarrinhocompra.Consultar());
        }

        public IActionResult RemoverItem(int id)
        {
            _cookiecarrinhocompra.Remover(new Livro() { codLivro = id });
            return RedirectToAction(nameof(Carrinho));
        }

        DateTime data;
        public IActionResult SalvarCarrinho(Emprestimo emprestimo)
        {
            List<Livro> carrinho = _cookiecarrinhocompra.Consultar();

            Emprestimo mdE = new Emprestimo();
            Item mdI = new Item();

            data = DateTime.Now.ToLocalTime();

            mdE.dtEmp = data.ToString("dd/mm/aaaa");
            mdE.dtDev = data.AddDays(7).ToString();
            mdE.codUsu = "1";
            _emprestimorepository.Cadastrar(mdE);
            _emprestimorepository.buscaIdEmp(emprestimo);

            for(int i = 0; i < carrinho.Count; i++)
            {
                mdI.codEmp = Convert.ToInt32(emprestimo.codEmp);
                mdI.codlivro = Convert.ToString(carrinho[i].codLivro);

                _itemRepository.Cadastrar(mdI);
            }
            _cookiecarrinhocompra.RemoverTodos();
            return RedirectToAction("confEmp");
        }

        public IActionResult confEmp()
        {
            return View();
        }

         
        
    }
}