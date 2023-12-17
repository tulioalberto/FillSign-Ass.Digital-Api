using FillSign.Ds.Data;
using FillSign.Ds.Services.Notification;
using System.Collections;
using FillSign.Ds.Domain;
using Microsoft.EntityFrameworkCore;

namespace FillSign.Ds.Application.CommandHandlers
{
    public class DocumentApplication : IDocumentApplication
    {
        private readonly ApiDbContext? _context;
        private readonly INotificationDomain<NotificationDomainMessage>? _notifications;
        public DocumentApplication(ApiDbContext context,
            INotificationDomain<NotificationDomainMessage> notifications)
        {
            _context = context;
            _notifications = notifications;
        }

        public DocumentApplication() { }

        public async Task<Document> GetDocumentById(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                _notifications.Add(new NotificationDomainMessage("Documento não encontrado."));
            }

            return document;
        }

        public async Task<Document> CreateDocument(Document document)
        {
            if (document == null)
            {
                _notifications.Add(new NotificationDomainMessage("Erro ao criar um documento, contate o suporte!"));
            }

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return document;
        }

        public async Task<Document> UpdateDocument(int id, Document document)
        {
            if (id != document.Id)
                _notifications.Add(new NotificationDomainMessage("Produto não encontrado."));

            _context.Entry(document).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
                    _notifications.Add(new NotificationDomainMessage("Produto não encontrado."));
                else
                {
                    throw;
                }
            }
            return document;
        }

        public async Task<Document> DeleteDocument(int id, Document document)
        {
            var documents = await _context.Documents.FindAsync();
            if (id != document.Id)
                _notifications.Add(new NotificationDomainMessage("Produto não encontrado."));

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return document;
        }

        private bool DocumentExists(int id)
        {
            return (_context.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
