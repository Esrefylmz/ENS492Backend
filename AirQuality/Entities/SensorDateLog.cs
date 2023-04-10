using System;
using System.Collections.Generic;

namespace AirQuality.Entities;

public partial class SensorDateLog
{
    public int LogId { get; set; }

    public string? MacId { get; set; }

    public string? RoomName { get; set; }

    public string? BuildingName { get; set; }

    public string? LocationInfo { get; set; }

    public int? CompanyId { get; set; }

    public DateTime LogDate { get; set; }

}

