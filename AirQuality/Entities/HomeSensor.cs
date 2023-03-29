using System;
using System.Collections.Generic;

namespace AirQuality.Entities;

public partial class HomeSensor
{
    public int SensorId { get; set; }

    public int HomeId { get; set; }

    public string Location { get; set; } = null!;

    public virtual Home Home { get; set; } = null!;
}
