using Bad.Notifications.Exceptions;
using Bad.Notifications.Models;
using Bad.Notifications.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bad.Notifications.Services
{
    public class BadNotificationsService : IBadNotificationsService
    {
        private readonly IBadNotificationsRepository _badNotificationsRepository;
        private readonly ILogger<BadNotificationsService> _logger;

        public BadNotificationsService(IBadNotificationsRepository badNotificationsRepository,
            ILogger<BadNotificationsService> logger)
        {
            _badNotificationsRepository = badNotificationsRepository;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forUserId">UserId for which to get notifications</param>
        /// <param name="beforeDate">Get notifications before this date</param>
        /// <param name="getCount">How many records to load?</param>
        /// <returns></returns>
        public async Task<IEnumerable<BadNotificationMessage>> GetNotifications(string forUserId, DateTime? beforeDate, int getCount = 5)
        {
            var inputs = new { forUserId, beforeDate };
            _logger.LogDebug($"Entered {nameof(BadNotificationsService)}.{nameof(GetNotifications)}. Inputs: {inputs}");

            return await _badNotificationsRepository.Get(n => n.Recipient == forUserId && (beforeDate == null || n.DateCreated < beforeDate),
                n => n.OrderByDescending(i => i.DateCreated))
                .Take(getCount)
                .ToListAsync();
        }

        public async Task<GetNewNotificationsResultModel> GetNewNotifications(string forUserId, DateTime afterDate)
        {
            var inputs = new { forUserId, afterDate };
            _logger.LogDebug($"Entered {nameof(BadNotificationsService)}.{nameof(GetNotifications)}. Inputs: {inputs}");

            var notifications = await _badNotificationsRepository.Get(n => n.Recipient == forUserId && n.DateCreated > afterDate,
                n => n.OrderByDescending(i => i.DateCreated))
                .ToListAsync();

            return new GetNewNotificationsResultModel
            {
                Notifications = notifications,
                UnviewedCount = await GetUnviewedCountAsync(forUserId)
            };
        }
        public async Task<UnviewedCountModel> GetUnviewedCountAsync(string userId)
        {
            return new UnviewedCountModel
            {
                Count = await _badNotificationsRepository.Get(n => n.Recipient == userId && !n.IsViewed && n.Status == Enums.BadNotificationMessageStatusEnum.Shown).CountAsync(),
                AsOf = DateTime.UtcNow
            };
        }

        public async Task<UnviewedCountModel> SetIsViewedAsync(int notificationId, string userId, bool isViewed = true)
        {
            var notification = await _badNotificationsRepository.GetByIDAsync(notificationId);
            if (notification.Recipient == userId)
            {
                notification.IsViewed = isViewed;
                await _badNotificationsRepository.SaveChangesAsync();
                return await GetUnviewedCountAsync(userId);
            }
            else
            {
                throw new BadNotificationException(BadNotificationExceptionType.NotNotificationRecipient,
                    "User tried to set IsViewed of a notification that's intended for someone else.");
            }
        }
    }

    public interface IBadNotificationsService
    {
        Task<IEnumerable<BadNotificationMessage>> GetNotifications(string forUserId, DateTime? beforeDate, int getCount = 5);
        Task<GetNewNotificationsResultModel> GetNewNotifications(string forUserId, DateTime afterDate);
        Task<UnviewedCountModel> GetUnviewedCountAsync(string forUserId);
        Task<UnviewedCountModel> SetIsViewedAsync(int notificationId, string userId, bool isViewed = true);
    }
}
