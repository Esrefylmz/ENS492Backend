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
    public class CompanySensorsController : ControllerBase
    {

        private readonly Ens4912AirqualityContext? _context;
        public CompanySensorsController(Ens4912AirqualityContext? context)
        {
            _context = context;
        }
        // GET: api/<CompanySensorsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOCompanySensor>>> GetBuildings()
        {
            var List = await _context.CompanySensors.Select(
                s => new DTOCompanySensor
                {
                     SoftId = s.SoftId,

                     MacId = s.MacId,

                    CompanyId = s.CompanyId,

                    RoomId = s.RoomId,

                    LocationInfo = s.LocationInfo,

                    RoomName = s.RoomName,

                    BuildingName = s.BuildingName,

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

        // GET api/<CompanySensorsController>/5
        [HttpGet("GetCompanySensorById")]
        public async Task<ActionResult<List<DTOCompanySensor>>> GetCompanySensorById(int Id)
        {
            var sensors = await _context.CompanySensors
                .Where(s => s.CompanyId == Id)
                .Select(s => new DTOCompanySensor
                {
                    SoftId = s.SoftId,
                    MacId = s.MacId,
                    CompanyId = s.CompanyId,
                    RoomId = s.RoomId,
                    LocationInfo = s.LocationInfo,
                    RoomName = s.RoomName,
                    BuildingName = s.BuildingName
                })
                .ToListAsync();

            if (sensors == null || sensors.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return sensors;
            }
        }


        // POST api/<CompanySensorsController>
        [HttpPost("PostCompanySensor")]
        public async Task<ActionResult<DTOCompanySensor>> PostCompanySensor(DTOCompanySensor Sensor)
        {
            var entity = new CompanySensor()
            {
                SoftId = Sensor.SoftId,

                MacId = Sensor.MacId,

                CompanyId = Sensor.CompanyId,

                RoomId = Sensor.RoomId,

                LocationInfo = Sensor.LocationInfo,

                RoomName = Sensor.RoomName,

                BuildingName = Sensor.BuildingName,
            };
            _context.CompanySensors.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanySensorById", new { id = Sensor.SoftId }, Sensor);
        }

        // PUT api/<CompanySensorsController>/5
        [HttpPut("PutCompanySensor")]
        public async Task<HttpStatusCode> PutCompanySensor(DTOCompanySensor sensor)
        {
            var entity = await _context.CompanySensors.FirstOrDefaultAsync(s => s.SoftId == sensor.SoftId);

            entity.MacId = sensor.MacId;

            entity.CompanyId = sensor.CompanyId;

            entity.RoomId = sensor.RoomId;

            entity.LocationInfo = sensor.LocationInfo;

            entity.RoomName = sensor.RoomName;

            entity.BuildingName = sensor.BuildingName;


            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        // DELETE api/<CompanySensorsController>/5
        [HttpDelete("DeleteCompanySensorsById")]
        public async Task<HttpStatusCode> DeleteCompanySensorsById(int id)
        {
            var entity = new CompanySensor()
            {
                SoftId = id
            };
            _context.CompanySensors.Attach(entity);
            _context.CompanySensors.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
