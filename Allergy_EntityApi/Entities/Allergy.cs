using System;
using System.Collections.Generic;

namespace EntityApi.Entities;

public partial class Allergy
{
    public int Id { get; set; }

    public int? VisitId { get; set; }

    public string? AllergyName { get; set; }

    public string? Notes { get; set; }
}
