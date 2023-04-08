using AirQuality.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserAuthController : ControllerBase
    {
        private readonly Ens4912AirqualityContext? _context;

        public CompanyUserAuthController(Ens4912AirqualityContext? context)
        {
            _context = context;
        }


        [HttpPost("RegisterCompanyUser")]
        public async Task<CompanyUser> RegisterCompanyUser(CompanyUser newCompanyUser)
        {
            CompanyUser CompanyUserSearch = await _context.CompanyUsers.Select(s => new CompanyUser
            {
                UserId = s.UserId,
                Usermail = s.Usermail,
                Password = s.Password,
                UserType = s.UserType,
                Username = s.Username,
                CompanyId = s.CompanyId,
                
            }).FirstOrDefaultAsync(s => s.Usermail == newCompanyUser.Usermail);

            if (CompanyUserSearch == null)
            {
                var entity = new CompanyUser()
                {
                    Username = newCompanyUser.Username,
                    Usermail = newCompanyUser.Usermail,
                    Password = newCompanyUser.Password,
                    UserType = newCompanyUser.UserType,
                    CompanyId = newCompanyUser.CompanyId,
                };
                _context.CompanyUsers.Add(entity);
                await _context.SaveChangesAsync();

                return await _context.CompanyUsers.Select(s => new CompanyUser
                {
                    UserId = s.UserId,
                    CompanyId = s.CompanyId,
                    Username = s.Username,
                    Usermail = s.Usermail,
                    Password = s.Password,
                    UserType = s.UserType,
                }).FirstOrDefaultAsync(s => s.Usermail == newCompanyUser.Usermail);
            }

            else
            {
                return null;
            }

        }


        [HttpPost("LoginCompanyUser")]
        public async Task<CompanyUser> LoginCompanyUser(UserLoginInfo companyUserToLogIn)
        {
            CompanyUser currentUser = await _context.CompanyUsers.Select(s => new CompanyUser
            {
                UserId = s.UserId,
                CompanyId = s.CompanyId,
                Username = s.Username,
                Usermail = s.Usermail,
                Password = s.Password,
                UserType = s.UserType,
            }).FirstOrDefaultAsync(s => s.Usermail == companyUserToLogIn.Mail);


            if (currentUser == null)
            {
                return null;
            }

            else if (currentUser.Password == companyUserToLogIn.Password)
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
