using Microsoft.CodeAnalysis.CodeActions;
using MySql.Data.MySqlClient;
using ProjEmprestimo.Models;
using ProjEmprestimo.Repository.Contract;

namespace ProjEmprestimo.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly string _conexaoMySQL;

        public EmprestimoRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        public void buscaIdEmp(Emprestimo emprestimo)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlDataReader dr;

                MySqlCommand cmd = new MySqlCommand("SELECT codEmp FROM tbEmprestimo ORDER BY codEmp DESC limit 1", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emprestimo.codEmp = dr[0].ToString();
                }
                conexao.Close();
            }
        }

        public void Cadastrar(Emprestimo emprestimo)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbEmprestimo values(default, @dtEmp, @dtDev, @codUsu)", conexao);

                cmd.Parameters.Add("@dtEmp", MySqlDbType.VarChar).Value = emprestimo.dtEmp;
                cmd.Parameters.Add("@dtDev", MySqlDbType.VarChar).Value = emprestimo.dtDev;
                cmd.Parameters.Add("@codUsu", MySqlDbType.VarChar).Value = emprestimo.codUsu;
                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Emprestimo ObterEmprestimos(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Emprestimo> ObterTodosItens()
        {
            throw new NotImplementedException();
        }
    }
}
