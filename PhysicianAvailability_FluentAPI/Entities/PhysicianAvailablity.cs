using System;
using System.Collections.Generic;

namespace FluentAPI.Entities;

public partial class PhysicianAvailablity
{
    public string PhysicianEmail { get; set; } = null!;

    public string? AvailableFrom { get; set; }

    public string? AvailableTo { get; set; }
}
