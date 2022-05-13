using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastrosApi.Models
{
    [Table("TbCadastro")]
    public class CadastrarUsuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email é obrigatório")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[ a-z0-9]+)*\\.([az]{2,4})$", ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(maximumLength:80, MinimumLength = 5)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Último nome é obrigatório")]
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string UtimoNome { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "A confirmação de é obrigatório")]
        [DataType(DataType.Password)]
        public string ConfirmarPassword { get; set; }
    }
}
