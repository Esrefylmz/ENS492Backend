using AirQuality.DbTransferObjects;
using AirQuality.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementTypeController : ControllerBase
    {
        private readonly Ens4912AirqualityContext? _context;

        public MeasurementTypeController(Ens4912AirqualityContext? context)
        {
            _context = context;
        }
        // GET: api/<MeasurementTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOMeasurementType>>> GetMeasurementTypes()
        {
            var List = await _context.MeasurementTypes.Select(
                s => new DTOMeasurementType
                {
                    MeasurementTypeId = s.MeasurementTypeId,
                    MeasurementType1 = s.MeasurementType1,
                    Unit = s.Unit,
                    MeasurementKey = s.MeasurementKey,
                    MinValue = s.MinValue,
                    MaxValue = s.MaxValue,
                    NormalMin = s.NormalMin,
                    NormalMax = s.NormalMax,
                    DisplayOrder = s.DisplayOrder,
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
    }
}
