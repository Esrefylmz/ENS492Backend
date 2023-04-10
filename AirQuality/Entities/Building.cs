using System;
using System.Collections.Generic;

namespace AirQuality.Entities;

public partial class Building
{
    public int BuildingId { get; set; }

    public string Name { get; set; } = null!;

    public int CompanyId { get; set; }
}
