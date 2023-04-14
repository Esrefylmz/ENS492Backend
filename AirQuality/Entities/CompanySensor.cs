using System;
using System.Collections.Generic;

namespace AirQuality.Entities;

public partial class CompanySensor
{
    public int SoftId { get; set; }

    public string MacId { get; set; } = null!;

    public int CompanyId { get; set; }

    public int RoomId { get; set; }

    public string LocationInfo { get; set; } = null!;

    public int BuildingId { get; set; }

}
