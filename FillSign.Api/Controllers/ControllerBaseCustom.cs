using FillSign.Ds.Services.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FillSign.Ds.Api.Controllers
{
    public class ControllerBaseCustom : ControllerBase
    {
        public readonly INotificationDomain<NotificationDomainMessage> _notifications;
        public ControllerBaseCustom(
            INotificationDomain<NotificationDomainMessage> notifications)
        {
            _notifications = notifications;
        }


        protected new IActionResult Response(object result = null)
        {
            if (IsSuccess)
                return Ok(new { data = (object) null });
            else 
            {
                var str = new StringBuilder();
                _notifications.GetAll().Select(n => n.Message).ToList().ForEach(error =>
                {
                    str.AppendLine(error);
                });
                return BadRequest(str.ToString());
            }
        }
        protected bool IsSuccess
        {
            get
            {
                return !_notifications.HasNotifications();
            }
        }
    }
}

