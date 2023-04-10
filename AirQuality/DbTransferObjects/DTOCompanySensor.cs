using AirQuality.Entities;

namespace AirQuality.DbTransferObjects
{
    public class DTOCompanySensor
    {
        public int SoftId { get; set; }

        public string MacId { get; set; }

        public int CompanyId { get; set; }

        public int RoomId { get; set; }

        public string LocationInfo { get; set; } = null!;

        public string RoomName { get; set; } = null!;

        public string BuildingName { get; set; } = null!;

    }
}
