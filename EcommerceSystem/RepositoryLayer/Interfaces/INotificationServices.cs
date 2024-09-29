using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface INotificationServices
    {
        public Task<IEnumerable<Notification>> GetNotifications(int customerId);
        public Task<Notification> PostNotification(Notification notification);
        public  Task<Notification> MarkAsRead(int id);
}
}
