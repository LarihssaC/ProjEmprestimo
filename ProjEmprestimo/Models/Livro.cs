using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjEmprestimo.Models
{
    public class Livro
    {
        public int codLivro { get; set; }
        [DisplayName("XYZ")]
        public string nomeLivro { get; set; }
        public string imgLivro { get; set; }
        public int quantidade { get; set; }
    }
}
