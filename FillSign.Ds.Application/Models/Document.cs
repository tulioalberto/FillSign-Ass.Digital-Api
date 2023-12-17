using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Application.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public Type Type { get; set; }

        public List<Signer> Signers { get; set; }
    }
    public enum Type
    {
        Document = 1, Contract = 2
    }
}
