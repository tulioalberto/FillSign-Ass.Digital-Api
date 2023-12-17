﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace FillSign.Ds.Services.Notification
{
    public class NotificationDomain : INotificationDomain<NotificationDomainMessage>
    {
        private List<NotificationDomainMessage> _notifications;

        public NotificationDomain()
        {
            _notifications = new List<NotificationDomainMessage>();
        }

        public void Add(NotificationDomainMessage notification)
        {
            _notifications.Add(notification);
        }

        public virtual List<NotificationDomainMessage> GetAll()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }

        public virtual bool ContainsNotification(string text)
        {
            return _notifications.Where(a => a.Message.Contains(text)).FirstOrDefault() != null ? true : false;
        }

        public void Dispose()
        {
            _notifications = new List<NotificationDomainMessage>();
        }

    }

}
