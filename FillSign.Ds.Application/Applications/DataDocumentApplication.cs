using FillSign.Ds.Application.Interface;
using FillSign.Ds.Services.Notification;
using FillSign.Ds.Domain.Data;

namespace FillSign.Ds.Application.Applications
{
    internal class DataDocumentApplication : IDataDocumentApplication
    {
        private readonly ApiDbContext _context;
        public DataDocumentApplication(ApiDbContext context,
            INotificationDomain<NotificationDomainMessage> notifications) : base(notifications)
        {
            _context = context;
        }
        public DataDocumentApplication() { }
    }
}
