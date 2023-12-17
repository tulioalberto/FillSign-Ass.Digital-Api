using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Services.Notification
{
    public interface INotificationDomain<NotificationDomainMessage>
    {
        void Add(NotificationDomainMessage notification);
        List<NotificationDomainMessage> GetAll();
        bool HasNotifications();
        bool ContainsNotification(string text);
        void Dispose();
    }
}
