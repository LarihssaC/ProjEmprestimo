using MySql.Data.MySqlClient;
using ProjEmprestimo.Models;
using ProjEmprestimo.Repository.Contract;
using System.Data;

namespace ProjEmprestimo.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly string _conexaoMySQL;
        public LivroRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public IEnumerable<Livro> ObtertodosLivros()
        {
            List<Livro> Livrolist = new List<Livro>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbLivro", conexao);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                conexao.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    Livrolist.Add(
                        new Livro
                        {
                            codLivro = Convert.ToInt32(dr["codLivro"]),
                            nomeLivro = (String)(dr["nomeLivro"]),
                            imgLivro = (String)(dr["imgLivro"]),
                        });
                }
                return Livrolist;
            }

        }

        public void Cadastrar(Livro livro)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbLivro values(default, @NomeLivro, @ImgLivro)", conexao);

                cmd.Parameters.Add("@NomeLivro", MySqlDbType.VarChar).Value = livro.nomeLivro;
                cmd.Parameters.Add("@ImgLivro", MySqlDbType.VarChar).Value = livro.imgLivro;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Atualizar(Livro livro)
        {
            

        }

        public Livro ObterLivros(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbLivro where codLivro = @cod", conexao);
                cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = Id;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Livro livro = new Livro();
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    livro.codLivro = Convert.ToInt32(dr["codLivro"]);
                    livro.nomeLivro = (String)(dr["nomeLivro"]);
                    livro.imgLivro = (string)(dr["imgLivro"]);
                }
                return livro;
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
