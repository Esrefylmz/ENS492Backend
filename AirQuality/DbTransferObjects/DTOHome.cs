using AirQuality.Entities;

namespace AirQuality.DbTransferObjects
{
    public class DTOHome
    {
        public int HomeId { get; set; }

        public string HomeName { get; set; } = null!;

        public virtual ICollection<HomeSensor> HomeSensors { get; } = new List<HomeSensor>();

        public virtual ICollection<HomeUser> HomeUsers { get; } = new List<HomeUser>();
    }
}
