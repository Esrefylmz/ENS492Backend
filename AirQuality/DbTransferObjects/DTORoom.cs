using AirQuality.Entities;

namespace AirQuality.DbTransferObjects
{
    public class DTORoom
    {
        public int RoomId { get; set; }

        public string Name { get; set; } = null!;

        public int BuildingId { get; set; }

    }
}
