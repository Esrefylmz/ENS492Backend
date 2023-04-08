using AirQuality.Entities;

namespace AirQuality.DbTransferObjects
{
    public class DTOCompany
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Domain { get; set; }

        public string Ssid { get; set; }

        public string Broker { get; set; }

    }
}
