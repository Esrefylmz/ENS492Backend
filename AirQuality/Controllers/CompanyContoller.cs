using AirQuality.DbTransferObjects;
using AirQuality.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
