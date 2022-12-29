using Bad.Core.Models;
using Bad.Notifications.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bad.Notifications.Models
{
    public class BadNotificationMessage:BaseEntityModel<long>
    {
        public string Data { get; set; }
        public string Recipient { get; set; }
        public bool IsViewed { get; set; } = false;
        public BadNotificationMessageStatusEnum Status { get; set; } = BadNotificationMessageStatusEnum.Shown;
        public int Type { get; set; }

        public BadNotificationMessage(int type, string recipient, string data)
        {
            Type = type;
            Recipient = recipient;
            Data = data;
        }
    }
}
