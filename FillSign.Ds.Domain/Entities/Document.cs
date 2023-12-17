using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Domain
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public Type Type { get; set; }

        public List<Signer> Signers { get; set; } = new List<Signer>();
    }
    public enum Type
    {
        Document = 1, Contract = 2
    }
}
