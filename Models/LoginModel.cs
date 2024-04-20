using System.ComponentModel.DataAnnotations;

namespace Filmes_Jogos.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Email é obrigatorio")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha é obrigatoria")]
        public string Senha { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha;//verificando senha
        }
    }
}
