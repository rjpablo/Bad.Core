using System;
using System.Collections.Generic;
using System.Text;

namespace Bad.Notifications.Models
{
    public class GetNewNotificationsResultModel
    {
        public UnviewedCountModel UnviewedCount { get; set; }
        public IEnumerable<object> Notifications { get; set; }
    }
}
