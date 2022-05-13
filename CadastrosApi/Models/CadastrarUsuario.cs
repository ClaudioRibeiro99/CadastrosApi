using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastrosApi.Models
{
    [Table("TbCadastro")]
    public class CadastrarUsuario
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Email invalido, verifique o email e tente nvoamente")]
        [Display(Description = "Digite um email")]
        [StringLength(maximumLength:80, MinimumLength = 5)]
        public string Email { get; set; }
        public string Nome { get; set; }
        public string UtimoNome { get; set; }
        public string Password { get; set; }
        public string ConfirmarPassword { get; set; }
    }
}
