using AirQuality.Entities;

namespace AirQuality.DbTransferObjects
{
    public class DTOCompany
    {
        public int CompanyId { get; set; }

        public Guid Name { get; set; }

        public Guid Domain { get; set; }

        public Guid Ssid { get; set; }

        public Guid Broker { get; set; }

        public virtual ICollection<Building> Buildings { get; } = new List<Building>();

        public virtual ICollection<CompanySensor> CompanySensors { get; } = new List<CompanySensor>();

        public virtual ICollection<CompanyUser> CompanyUsers { get; } = new List<CompanyUser>();
    }
}
