
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using BlazorWASM.WebAPI.Models;

namespace BlazorWASM.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> logger;
        private readonly BlazorWASMContext _context;

        public SettingsController(ILogger<SettingsController> logger, BlazorWASMContext context)
        {
            this.logger = logger;
            _context = context;
        }

        [HttpPut("updatetheme/{userId}")]
        public async Task<User> UpdateTheme(string userId, User user)
        {
            User userToUpdate = _context.Users.Where(u => u.UserId == Convert.ToInt32(userId)).FirstOrDefault();
            userToUpdate.DarkTheme = user.DarkTheme; //== "True" ? 1 : 0;

            await _context.SaveChangesAsync();

            return await Task.FromResult(user);
        }

        [HttpPut("updatenotifications/{userId}")]
        public async Task<User> UpdateNotifications(string userId, User user)
        {
            User userToUpdate = _context.Users.Where(u => u.UserId == Convert.ToInt32(userId)).FirstOrDefault();
            userToUpdate.Notifications = user.Notifications;// == "True" ? 1 : 0;

            await _context.SaveChangesAsync();

            return await Task.FromResult(user);
        }
    }
}
