using AirQuality.DbTransferObjects;
using AirQuality.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorDataController : ControllerBase
    {
        private readonly Ens4912AirqualityContext? _context;

        public MonitorDataController(Ens4912AirqualityContext? context)
        {
            _context = context;
        }

        [HttpGet("GetDataByMacId")]
        public async Task<ActionResult<IEnumerable<DTOMonitorDatum>>> GetDataByMacId(string macID)
        {
            var List = await _context.MonitorData
                .Where(s => s.MacId == macID)
                .Select(s => new DTOMonitorDatum
                {
                    MacId = s.MacId,
                    MeasurementId = s.MeasurementId,
                    MeasurementTypeId = s.MeasurementTypeId,
                    MeasurementValue = s.MeasurementValue,
                    Timestamp = s.Timestamp,
                    
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
    }
}
