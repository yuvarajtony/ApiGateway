using System;
using System.Collections.Generic;

namespace audit_service.Entities;

public partial class BloodPressureSystolicTable
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public string? Date { get; set; }

    public int? Value { get; set; }
}
