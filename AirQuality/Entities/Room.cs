using System;
using System.Collections.Generic;

namespace AirQuality.Entities;

public partial class Room
{
    public int RoomId { get; set; }

    public string Name { get; set; } = null!;

    public int BuildingId { get; set; }

}
