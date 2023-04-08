using AirQuality.Entities;

namespace AirQuality.DbTransferObjects
{
    public class DTOBuilding
    {
        public int BuildingId { get; set; }

        public string Name { get; set; } = null!;

        public int CompanyId { get; set; }

    }
}
