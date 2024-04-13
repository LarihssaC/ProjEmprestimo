using MySql.Data.MySqlClient;
using ProjEmprestimo.Repository.Contract;
using ProjEmprestimo.Models;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ProjEmprestimo.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _connexaoMySQL;
        public ItemRepository(IConfiguration conf)
        {
            _connexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }


        public void Atualizar(DocumentFormat.OpenXml.Spreadsheet.Item item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Item item)
        {
            using (var conexao = new MySqlConnection(_connexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into ItensEmp values(default, @codEmp, @codLivro)", conexao);

                cmd.Parameters.Add("@codEmp", MySqlDbType.VarChar).Value = item.codEmp;
                cmd.Parameters.Add("@codLivro", MySqlDbType.VarChar).Value = item.codLivro;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> ObterTodosItens()
        {
            throw new NotImplementedException();
        }

        public Item ObterTodosItens(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DocumentFormat.OpenXml.Spreadsheet.Item> IItemRepository.ObterTodosItens()
        {
            throw new NotImplementedException();
        }

        DocumentFormat.OpenXml.Spreadsheet.Item IItemRepository.ObterTodosItens(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
