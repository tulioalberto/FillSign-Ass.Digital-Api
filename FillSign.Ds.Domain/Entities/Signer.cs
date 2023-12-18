using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Domain
{
    public class Signer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }
        public ICollection<DocumentSigner> DocumentSigners { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
    public enum Status { Active =  1, Inactive = 1}
}
