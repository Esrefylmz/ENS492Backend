namespace AirQuality.DbTransferObjects
{
    public class DTOSensorDateLog
    {
        public int LogId { get; set; }

        public string MacId { get; set; }

        public string RoomName { get; set; }

        public int? BuildingId { get; set; }

        public string LocationInfo { get; set; }

        public int? CompanyId { get; set; }

        public DateTime LogDate { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public string Usermail { get; set; }

        public string OldLocationInfo { get; set; }

        public int? OldBuildingId { get; set; }

        public int? OldRoomId { get; set; }

        public string OldRoomName { get; set; }

        public int? RoomId { get; set; }
    }
}
