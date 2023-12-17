using FillSign.Ds.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Application.CommandHandlers
{
    public interface IDocumentApplication
    {
        Task<Document> GetDocumentById(int id);
        Task<Document> CreateDocument(Document documento);
        Task<Document> UpdateDocument(int id, Document document);
        Task<Document> DeleteDocument(int id, Document document);
    }
}
