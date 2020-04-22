using Announcer.Contracts;
using Announcer.Dtos.Requests;
using Announcer.Hubs;
using Announcer.Models;
using Announcer.Services.Communication;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Announcer.Services
{
    /// <summary>
    /// Group notification entity service
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class GroupNotificationService : IGroupNotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        protected readonly ILogger<GroupNotificationService> _logger;
        protected readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<Group> groupRepository;
        private readonly IRepository<Notification> notificationRepository;

        /// <summary>
        /// Group notification service constructor
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="unitOfWork">Unit of work instance</param>
        /// <param name="logger">Logger instance</param>
        public GroupNotificationService(IHubContext<NotificationHub> hubContext, IUnitOfWork unitOfWork, ILogger<GroupNotificationService> logger)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            groupRepository = _unitOfWork.GetRepository<Group>();
            notificationRepository = _unitOfWork.GetRepository<Notification>();
        }

        /// <inheritdoc/>
        public async Task<IResponse> SendMessageToGroup(SendGroupNotification groupNotification)
        {
            _logger.LogDebug($"'{nameof(SendMessageToGroup)}' has been invoked");

            var response = new Response();

            try
            {
                var group = await groupRepository.GetAsync(g => g.Name == groupNotification.GroupName);
                if (group == null) throw new Exception($"No group found with name '{groupNotification.GroupName}'");

                var notification = await notificationRepository.GetAsync(n => n.Group.Name == groupNotification.GroupName);
                if (notification == null)
                {
                    await notificationRepository.AddAsync(new Notification { Content = groupNotification.Message, GroupId = group.Id, SenderId = "" });
                }
                else
                {
                    notification.Content = groupNotification.Message;
                    notification.SentTime = DateTime.Now;
                    notificationRepository.Update(notification);
                }

                await _unitOfWork.SaveAsync();

                await _hubContext.Clients.Group(groupNotification.GroupName).SendAsync("ReceiveGroupMessage", new
                {
                    Group = groupNotification.GroupName,
                    groupNotification.Message
                });

                response.Message = $"Notification sent to {groupNotification.GroupName} group successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error on '{0}' invocation: {1}", nameof(SendMessageToGroup), (ex.InnerException != null) ? ex.InnerException.Message : ex.Message);

                response.IsSuccessful = false;
                response.Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
            }

            return response;
        }
    }
}