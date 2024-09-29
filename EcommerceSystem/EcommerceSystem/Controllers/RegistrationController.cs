using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace OnlineBookOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
       
            private readonly EcommerceDBContext _context;
            private readonly IConfiguration _configuration;

            public RegistrationController(EcommerceDBContext context, IConfiguration configuration)
            {
                _context = context;
                _configuration = configuration;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = await _context.Customers.SingleOrDefaultAsync(u => u.Name == model.Username);
                if (existingUser != null)
                {
                    return BadRequest("Username already exists.");
                }

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                var Customer = new Customer
                {
                    Name = model.Username,
                    Email = model.Email,
                    PasswordHash = hashedPassword,
                    Cart = new Cart {
                      
                    },
                    Orders =null
                    //Role = "User" // default role, change as needed

                };

                _context.Customers.Add(Customer);
                await _context.SaveChangesAsync();

                return Ok("Registration successful");
            
        }
    }
}
