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
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Type Type { get; set; }
        public string Attach { get; set; }
        public List<Signer> Signers { get; set; } = new List<Signer>();
        public ICollection<DocumentSigner> DocumentSigners { get; set; }
    }
    public enum Type
    {
        Document = 1, Contract = 2
    }

    public class DocumentSigner
    {
        public int DocumentSignerId { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public int SignerId { get; set; }
        public Signer Signer { get; set; }
    }
}
