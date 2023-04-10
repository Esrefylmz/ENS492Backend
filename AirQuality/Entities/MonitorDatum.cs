using System;
using System.Collections.Generic;

namespace AirQuality.Entities;

public partial class MonitorDatum
{
    public string MacId { get; set; } = null!;

    public ulong MeasurementId { get; set; }

    public short MeasurementTypeId { get; set; }

    public double MeasurementValue { get; set; }

    public DateTime Timestamp { get; set; }

}

