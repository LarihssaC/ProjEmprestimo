using ProjEmprestimo.Models;

namespace ProjEmprestimo.Repository.Contract
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> ObtertodosLivros();
        void Cadastrar (Livro livro);
        void Atualizar (Livro livro);
        Livro ObterLivros(int Id);
        void Excluir(int Id);
    }
}
