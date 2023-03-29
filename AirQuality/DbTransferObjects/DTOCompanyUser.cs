using AirQuality.Entities;

namespace AirQuality.DbTransferObjects
{
    public class DTOCompanyUser
    {
        public int UserId { get; set; }

        public string Usermail { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserType { get; set; } = null!;

        public string Username { get; set; } = null!;

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
