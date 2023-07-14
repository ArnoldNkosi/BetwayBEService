using System;
using System.Collections.Generic;

namespace BackendSolution.Models;

public partial class Address
{
    public Guid Id { get; set; }

    public string? Country { get; set; }

    public string? Region { get; set; }

    public string? StreetName { get; set; }

    public int? StreetNumber { get; set; }

    public Guid? PersonId { get; set; }

    public virtual Person? Person { get; set; }
}
