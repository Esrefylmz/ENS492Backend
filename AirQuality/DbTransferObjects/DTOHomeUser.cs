using AirQuality.Entities;

namespace AirQuality.DbTransferObjects
{
    public class DTOHomeUser
    {
        public string Usermail { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserType { get; set; } = null!;

        public string Username { get; set; } = null!;

        public int HomeId { get; set; }

        public virtual Home Home { get; set; } = null!;
    }
}
