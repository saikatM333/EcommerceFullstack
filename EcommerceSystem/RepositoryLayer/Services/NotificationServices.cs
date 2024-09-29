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

namespace RepositoryLayer.Services
{
    public class NotificationServices : INotificationServices
    {
       
            private readonly EcommerceDBContext _context;

            public NotificationServices(EcommerceDBContext context)
            {
                _context = context;
            }

            
            public async Task<IEnumerable<Notification>> GetNotifications(int customerId)
            {
                var notifications = await _context.Notifications
                    .Where(n => n.CustomerId == customerId)
                    .ToListAsync();

                return notifications;
            }

    
            public async Task<Notification> PostNotification(Notification notification)
            {
                _context.Notifications.Add(notification);
                await _context.SaveChangesAsync();
                return notification;
               // return CreatedAtAction("GetNotification", new { id = notification.Id }, notification);
            }

            
            public async Task<Notification> MarkAsRead(int id)
            {
                var notification = await _context.Notifications.FindAsync(id);

                if (notification == null)
                {
                    return null;
                }

                notification.IsRead = true;
                _context.Entry(notification).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(id))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }

                return notification;
            }

            private bool NotificationExists(int id)
            {
                return _context.Notifications.Any(e => e.Id == id);
            
        
            }

}
}
