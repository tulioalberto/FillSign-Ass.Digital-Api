using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Domain.Entities
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As Senhas não conferem")]
        public string ConfirmPasswork { get; set; }
    }
}
