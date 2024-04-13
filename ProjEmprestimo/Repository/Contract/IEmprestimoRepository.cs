using ProjEmprestimo.Models;

namespace ProjEmprestimo.Repository.Contract
{
    public interface IEmprestimoRepository
    {

        IEnumerable<Emprestimo> ObterTodosItens();
        void Cadastrar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        Emprestimo ObterEmprestimos(int Id);
        void buscaIdEmp(Emprestimo emprestimo);
        void Excluir(int Id);
    }
}
