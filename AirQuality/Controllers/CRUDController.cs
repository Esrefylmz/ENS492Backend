using AirQuality.DbTransferObjects;
using AirQuality.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly Ens4912AirqualityContext? _context;

        public CRUDController(Ens4912AirqualityContext? context)
        {
            _context = context;
        }
        [EnableCors("AllowOrigin")]
        // GET: api/<CRUDController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOBuilding>>> GetBuildings()
        {
            var List = await _context.Buildings.Select(
                s => new DTOBuilding
                {
                    BuildingId = s.BuildingId,
                    Name = s.Name,
                    CompanyId = s.CompanyId,
                    
            }).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }   
        }

        // GET api/<CRUDController>/5
        [HttpGet("GetBuildingById")]
        public async Task<ActionResult<DTOBuilding>> GetBuildingById(int Id)
        {
            DTOBuilding building = await _context.Buildings.Select(
                s => new DTOBuilding {
                    BuildingId = s.BuildingId,
                    Name = s.Name,
                    CompanyId = s.CompanyId,
                }).FirstOrDefaultAsync(s => s.BuildingId == Id);

            if (building == null)
            {
                return NotFound();
            }
            else
            {
                return building;
            }
        }

        // POST api/<CRUDController>
        [HttpPost("PostBuilding")]
        public async Task<ActionResult<DTOBuilding>> PostBuilding(DTOBuilding Building)
        {
            var entity = new Building()
            {
                BuildingId = Building.BuildingId,
                Name = Building.Name,
                CompanyId = Building.CompanyId,
            };
            _context.Buildings.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildings", new {id = Building.BuildingId }, Building);
        }

        // PUT api/<CRUDController>/5
        [HttpPut("PutBuilding")]
        public async Task<HttpStatusCode> PutBuilding(DTOBuilding building)
        {
            var entity = await _context.Buildings.FirstOrDefaultAsync(s => s.BuildingId == building.BuildingId);

            entity.Name = building.Name;
            entity.CompanyId = building.CompanyId;
            

            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        // DELETE api/<CRUDController>/5
        [HttpDelete("DeleteBuilding{id}")]
        public async Task<HttpStatusCode> DeleteBuilding(int id)
        {
            var entity = new Building()
            {
                BuildingId = id
            };
            _context.Buildings.Attach(entity);
            _context.Buildings.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        private bool DTOBuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.BuildingId == id);
        }
    }
}
