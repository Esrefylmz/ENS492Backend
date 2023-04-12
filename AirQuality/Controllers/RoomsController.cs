using AirQuality.DbTransferObjects;
using AirQuality.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQuality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly Ens4912AirqualityContext? _context;

        public RoomsController(Ens4912AirqualityContext? context)
        {
            _context = context;
        }

        // GET api/<RoomsController>/5
        [HttpGet("GetRoomsByBuildingId")]
        public async Task<ActionResult<IEnumerable<DTORoom>>> GetRoomsByBuildingId(int buildingId)
        {
            var List = await _context.Rooms
                .Where(s => s.BuildingId == buildingId)
                .Select(s => new DTORoom
                {
                    BuildingId = s.BuildingId,
                    Name = s.Name,
                    RoomId = s.RoomId
                })
                .ToListAsync();

            if (List.Count < 1)
            {
                return List;
            }
            else
            {
                return List;
            }
        }







        // POST api/<RoomsController>
        [HttpPost("PostRoom")]
        public async Task<ActionResult<DTORoom>> PostBuilding(DTORoom Room)
        {
            var entity = new Room()
            {
                BuildingId = Room.BuildingId,
                Name = Room.Name,
                RoomId = Room.RoomId,
            };
            _context.Rooms.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostRoom", new { id = Room.RoomId }, Room);
        }

        // PUT api/<RoomsController>/5
        [HttpPut("PutRoom")]
        public async Task<HttpStatusCode> PutRoom(DTORoom room)
        {
            var entity = await _context.Rooms.FirstOrDefaultAsync(s => s.RoomId == room.RoomId);

            entity.Name = room.Name;
            entity.BuildingId = room.BuildingId;


            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("DeleteRoom{id}")]
        public async Task<HttpStatusCode> DeleteRoom(int id)
        {
            var entity = new Room()
            {
                RoomId = id
            };
            _context.Rooms.Attach(entity);
            _context.Rooms.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
