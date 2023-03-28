using System;
using System.Collections.Generic;

namespace audit_service.Entities;

public partial class BloodGroupTable
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public string? Date { get; set; }

    public string? Value { get; set; }
}
