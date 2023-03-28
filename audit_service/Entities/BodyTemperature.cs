using System;
using System.Collections.Generic;

namespace audit_service.Entities;

public partial class BodyTemperature
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public string? Date { get; set; }

    public double? Value { get; set; }
}
