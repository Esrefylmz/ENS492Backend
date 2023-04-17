using AirQuality.DbTransferObjects;
using AirQuality.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyContoller : ControllerBase
    {
        // GET: api/<companyUserAuth>
        private readonly Ens4912AirqualityContext? _context;

        public CompanyContoller(Ens4912AirqualityContext? context)
        {
            _context = context;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOCompany>>> GetCompanies()
        {
            var companyList = await _context.Companies.Select(
                s => new DTOCompany
                {
                    CompanyId = s.CompanyId,
                    Name = s.Name,
                    Domain = s.Domain,
                    Ssid = s.Ssid,
                    Broker = s.Broker,
                    Password = s.Password,
                }).ToListAsync();

            if (companyList.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return companyList;
            }
        }

        // GET api/<CompanyController>/5
        [HttpGet("GetCompanyByDomain")]
        public async Task<ActionResult<DTOCompany>> GetCompanyByDomain(string domain)
        {
            DTOCompany company = await _context.Companies.Select(
                s => new DTOCompany
                {
                    CompanyId = s.CompanyId,
                    Name = s.Name,
                    Domain = s.Domain,
                    Ssid = s.Ssid,
                    Broker = s.Broker,
                    Password = s.Password,

                }).FirstOrDefaultAsync(s => s.Domain == domain);

            if (company == null)
            {
                return NotFound();
            }
            else
            {
                return company;
            }
        }
        
        
        [HttpPost("CreateCompany")]
        public async Task<ActionResult<DTOCompany>> CreateCompany(DTOCompany Company)
        {
            var entity = new Company()
            {
                CompanyId = Company.CompanyId,
                Name = Company.Name,
                Domain = Company.Domain,
                Ssid = Company.Ssid,
                Broker = Company.Broker,
                Password = Company.Password,
            };
            _context.Companies.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateCompany", new { id = Company.CompanyId }, Company);
        }

        
        [HttpPut("UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(DTOCompany Company)
        {
            var entity = await _context.Companies.FirstOrDefaultAsync(s => s.CompanyId == Company.CompanyId);
            if (entity != null)
            {
                entity.Name = Company.Name;
                entity.Domain = Company.Domain;
                entity.Ssid = Company.Ssid;
                entity.Broker = Company.Broker;
                entity.Password = Company.Password;
                await _context.SaveChangesAsync();
                return HttpStatusCode.OK;
            }

            return HttpStatusCode.NotFound;
        }
    }
}
