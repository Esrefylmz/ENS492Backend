using System;
using System.Collections.Generic;

namespace AirQuality.Entities;

public partial class CompanySensor
{
    public int SoftId { get; set; }

    public int MacId { get; set; }

    public int CompanyId { get; set; }

    public int RoomId { get; set; }

    public string LocationInfo { get; set; } = null!;

    public string RoomName { get; set; } = null!;

    public string BuildingName { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
