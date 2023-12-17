using FillSign.Ds.Data;
using FillSign.Ds.Services.Notification;
using System.Collections;
using FillSign.Ds.Domain;

namespace FillSign.Ds.Application.CommandHandlers
{
    internal class DocumentApplication : IDocumentApplication
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

        



    }
}
