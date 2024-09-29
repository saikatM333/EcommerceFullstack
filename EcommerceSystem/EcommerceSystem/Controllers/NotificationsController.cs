using busnessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationServicesBL _notificationServicesBL;

        public NotificationsController(INotificationServicesBL notificationServicesBL)
        {
            _notificationServicesBL = notificationServicesBL;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications(int customerId)
        {
            var notifications = await _notificationServicesBL.GetNotifications(customerId);


            return Ok(notifications);
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> PostNotification(Notification notification)
        {
            var data  = _notificationServicesBL.PostNotification(notification); 
            if (data != null)
            {
                return CreatedAtAction("GetNotification", new { id = notification.Id }, notification);
            }
            else
            {
                return BadRequest();
            }

            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var notification = await _notificationServicesBL.MarkAsRead(id);

            if (notification == null)
            {
                return NotFound();
            }

            else
            {

                return NoContent();

            }
        }
    }
}
