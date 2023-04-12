using AirQuality.Entities;

namespace AirQuality.DbTransferObjects
{
    public class DTOHomeSensor
    {
        public int SensorId { get; set; }

        public int HomeId { get; set; }

        public string Location { get; set; } = null!;

    }
}
