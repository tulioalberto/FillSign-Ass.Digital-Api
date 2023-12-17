using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Application.Models
{
    public class Signer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Document")]
        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }
    }
    public enum Status { Active =  1, Inactive = 1}
}
