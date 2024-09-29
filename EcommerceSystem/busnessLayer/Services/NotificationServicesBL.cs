using busnessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busnessLayer.Services
{
    public class NotificationServicesBL : INotificationServicesBL
    {
            private readonly INotificationServices _notificationServices;
            public NotificationServicesBL(INotificationServices notificationServices)
            {
                _notificationServices = notificationServices;
            }          
            public async Task<IEnumerable<Notification>> GetNotifications(int customerId)
            {
                return await _notificationServices.GetNotifications(customerId);
            }    
            public async Task<Notification> PostNotification(Notification notification)
            {               
                return await _notificationServices.PostNotification(notification);    
               // return CreatedAtAction("GetNotification", new { id = notification.Id }, notification);
            }            
            public async Task<Notification> MarkAsRead(int id)
            {
                return await _notificationServices.MarkAsRead(id);
            }
}
}
