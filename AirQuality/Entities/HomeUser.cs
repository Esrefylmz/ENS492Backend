using System;
using System.Collections.Generic;

namespace AirQuality.Entities;

public partial class HomeUser
{
    public int userId { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Username { get; set; } = null!;

    public int HomeId { get; set; }
}
