using AirQuality.DbTransferObjects;
using AirQuality.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUsersController : ControllerBase
    {
        // GET: api/<CompanyUsersController>
        // GET: api/<companyUserAuth>
        private readonly Ens4912AirqualityContext? _context;

        public CompanyUsersController(Ens4912AirqualityContext? context)
        {
            _context = context;
        }
        // GET api/<CompanyController>/5
        [HttpGet("GetCompanyViewersByCompanyId")]
        public async Task<ActionResult<IEnumerable<DTOCompanyUser>>> GetCompanyViewersByCompanyId(int id)
        {
            var List = await _context.CompanyUsers
                .Where(s => s.UserType == "viewer" && s.CompanyId == id)
                .Select(s => new DTOCompanyUser
                {
                    UserId = s.UserId,
                    Usermail = s.Usermail,
                    Password = s.Password,
                    UserType = s.UserType,
                    Username = s.Username,
                    CompanyId = s.CompanyId,
                    }).ToListAsync();
            if (List.Count < 1)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("GetCompanyPendingViewersByCompanyId")]
        public async Task<ActionResult<IEnumerable<DTOCompanyUser>>> GetCompanyPendingViewersByCompanyId(int id)
        {
            var List = await _context.CompanyUsers
                .Where(s => s.UserType == "pending" && s.CompanyId == id)
                .Select(s => new DTOCompanyUser
                {
                    UserId = s.UserId,
                    Usermail = s.Usermail,
                    Password = s.Password,
                    UserType = s.UserType,
                    Username = s.Username,
                    CompanyId = s.CompanyId,
                }).ToListAsync();
            if (List.Count < 1)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("GetCompanyAdminsByCompanyId")]
        public async Task<ActionResult<IEnumerable<DTOCompanyUser>>> GetCompanyAdminsByCompanyId(int id)
        {
            var List = await _context.CompanyUsers
                .Where(s => s.UserType == "admin" && s.CompanyId == id)
                .Select(s => new DTOCompanyUser
                {
                    UserId = s.UserId,
                    Usermail = s.Usermail,
                    Password = s.Password,
                    UserType = s.UserType,
                    Username = s.Username,
                    CompanyId = s.CompanyId,
                }).ToListAsync();
            if (List.Count < 1)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpPost("RegisterCompanyAdminFromWeb")]
        public async Task<CompanyUser> RegisterCompanyAdminFromWeb(CompanyUser newCompanyUser)
        {
            CompanyUser companyUserSearch = await _context.CompanyUsers.FirstOrDefaultAsync(s => s.Usermail == newCompanyUser.Usermail);

            if (companyUserSearch == null)
            {
                var entity = new CompanyUser()
                {
                    Username = newCompanyUser.Username,
                    Usermail = newCompanyUser.Usermail,
                    Password = newCompanyUser.Password,
                    UserType = "admin", 
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
        [HttpPut("ApprovePendingViewer")]
        public async Task<HttpStatusCode> ApprovePendingViewer(int userId)
        {
            var entity = await _context.CompanyUsers.FirstOrDefaultAsync(s => s.UserId == userId && s.UserType == "pending");
            if (entity != null)
            {
                entity.UserType = "viewer";
                await _context.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
            else
            {
                // Handle case where user with given userId and userType "pending" is not found
                return HttpStatusCode.NotFound;
            }
        }


        [HttpDelete("DisapprovePendingViewer/{id}")]
        public async Task<HttpStatusCode> DisapprovePendingViewer(int id)
        {
            var entity = new CompanyUser()
            {
                UserId = id
            };
            _context.CompanyUsers.Attach(entity);
            _context.CompanyUsers.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

    }
}
