using AirQuality.DbTransferObjects;
using AirQuality.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDateLogController : ControllerBase
    {
        private readonly Ens4912AirqualityContext? _context;

        public SensorDateLogController(Ens4912AirqualityContext? context)
        {
            _context = context;
        }
        // GET api/<SensorDateLogController>/5
        [HttpGet("GetSensorDateLogsByMacId")]
        public async Task<ActionResult<IEnumerable<DTOSensorDateLog>>> GetSensorDateLogsByMacId(string id)
        {
            var List = await _context.SensorDateLogs
                .Where(s => s.MacId == id)
                .Select(s => new DTOSensorDateLog
                {
                    LogId = s.LogId,
                    MacId = s.MacId,
                    RoomName = s.RoomName,
                    BuildingId = s.BuildingId,
                    LocationInfo = s.LocationInfo,
                    CompanyId = s.CompanyId,
                    LogDate = s.LogDate,
                    UserId = s.UserId,
                    Username = s.Username,
                    Usermail = s.Usermail,
                    OldLocationInfo = s.OldLocationInfo,
                    OldBuildingId = s.OldBuildingId,
                    OldRoomId = s.OldRoomId,
                    OldRoomName = s.OldRoomName,
                    RoomId = s.RoomId,
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

        [HttpPost("PostSensorDateLog")]
        public async Task<ActionResult<DTOSensorDateLog>> PostSensorDateLog(DTOSensorDateLog SensorLog)
        {
            var entity = new SensorDateLog()
            {
                LogId = SensorLog.LogId,
                MacId = SensorLog.MacId,
                RoomName = SensorLog.RoomName,
                BuildingId = SensorLog.BuildingId,
                LocationInfo = SensorLog.LocationInfo,
                CompanyId = SensorLog.CompanyId,
                LogDate = SensorLog.LogDate,
                UserId = SensorLog.UserId,
                Username = SensorLog.Username,
                Usermail = SensorLog.Usermail,
                OldLocationInfo = SensorLog.OldLocationInfo,
                OldBuildingId = SensorLog.OldBuildingId,
                OldRoomId = SensorLog.OldRoomId,
                OldRoomName = SensorLog.OldRoomName,
                RoomId = SensorLog.RoomId,
            };
            _context.SensorDateLogs.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostSensorDateLog", new { id = SensorLog.LogId }, SensorLog);
        }

    }
}
