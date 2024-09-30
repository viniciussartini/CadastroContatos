using System.ComponentModel.DataAnnotations;

namespace CadastroContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage ="E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Digite o telefone do contato")]
        [Phone(ErrorMessage ="Telefone inválido")]
        public string Telefone { get; set; }
    }
}
