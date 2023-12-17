using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Services.Notification
{
    public class NotificationDomainMessage
    {
        public DateTimeOffset Timestamp { get; private set; }
        public int MyProperty { get; private set; }
        public string Message { get; private set; }

        public NotificationDomainMessage(string message)
        {
            Timestamp = DateTimeOffset.Now;
            this.Message = message;
        }
    }
}
