using System;
using System.Collections.Generic;
using System.Text;

namespace Bad.Notifications.Exceptions
{
    public enum BadNotificationExceptionType
    {
        /// <summary>
        /// Tried perform an operation that is only allowed for notification recipient
        /// but the current user is not the notification's recipient
        /// </summary>
        NotNotificationRecipient = 0,
    }

    public class BadNotificationException:Exception
    {
        public BadNotificationExceptionType Type { get; set; }
        public BadNotificationException(BadNotificationExceptionType type, string message):base(message)
        {
            Type= type;
        }
    }
}
