using DocumentFormat.OpenXml.Spreadsheet;
using ProjEmprestimo.Models;

namespace ProjEmprestimo.Repository.Contract
{
    public interface IItemRepository
    {
        IEnumerable<Item> ObterTodosItens();
        void Cadastrar(Item item);
        void Atualizar(Item item);
        Item ObterTodosItens(int Id);
        void Excluir(int Id);
        void Cadastrar(DocumentFormat.OpenXml.Office.CustomUI.Item mdI);
    }
}
