using Bad.Core.Repositories;
using Bad.Notifications.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bad.Notifications.Repositories
{
    public class BadNotificationsRepository : BaseRepository<BadNotificationMessage, long>, IBadNotificationsRepository
    {
        public BadNotificationsRepository(DbContext context) : base(context)
        {

        }
    }

    public interface IBadNotificationsRepository : IRepository<BadNotificationMessage, long>
    {

    }
}
