using AirQuality.DbTransferObjects;
using AirQuality.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AirQuality.Controllers
{ 

    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
	{
        private readonly Ens4912AirqualityContext? _context;

        public UserController(Ens4912AirqualityContext? context)
        {
            _context = context;
        }


        [HttpPost("RegisterUser")]
        public async Task<HomeUser> UserRegistiration(HomeUser newUser)
        {
            HomeUser userSearch = await _context.HomeUsers.Select(s => new HomeUser
            {
                userId = s.userId,
                HomeId = s.HomeId,
                Username = s.Username,
                Mail = s.Mail,
                Password = s.Password,
            }).FirstOrDefaultAsync(s => s.Mail == newUser.Mail);

            if (userSearch == null)
            {
                var entity = new HomeUser()
                {
                    Username = newUser.Username,
                    Mail = newUser.Mail,
                    Password = newUser.Password,
                    HomeId = newUser.HomeId
                };
                _context.HomeUsers.Add(entity);
                await _context.SaveChangesAsync();
                
                return await _context.HomeUsers.Select(s => new HomeUser
                {
                    userId = s.userId,
                    HomeId = s.HomeId,
                    Username = s.Username,
                    Mail = s.Mail,
                    Password = s.Password,
                }).FirstOrDefaultAsync(s => s.Mail == newUser.Mail);
            }

            else
            {
                return null;
            }

        }


        [HttpPost("LoginUser")]
        public async Task<HomeUser> UserLogin(UserLoginInfo userToLogIn)
        {
            HomeUser currentUser = await _context.HomeUsers.Select(s => new HomeUser
            {
                userId = s.userId,
                HomeId = s.HomeId,
                Username = s.Username,
                Mail = s.Mail,
                Password = s.Password,
            }).FirstOrDefaultAsync(s => s.Mail == userToLogIn.Mail);


            if (currentUser == null)
            {
                return null;
            }

            else if (currentUser.Password == userToLogIn.Password)
            {
                currentUser.Password = null;

                return currentUser;
            }
            else
            {
                return null;
            }

        }
    }
}

