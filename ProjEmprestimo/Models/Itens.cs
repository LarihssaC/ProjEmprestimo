namespace ProjEmprestimo.Models
{
    public class Itens
    {
        public Guid ItemPedidoD { get; set; }
        public int codEmp { get; set; }
        public string codLivro { get; set; }
        public string nomeLivro { get; set; }
        public string img { get; set; }
        public string quantidade { get; set; }
    }
}
