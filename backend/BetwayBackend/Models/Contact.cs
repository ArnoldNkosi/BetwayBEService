using System;
using System.Collections.Generic;

namespace BackendSolution.Models;

public partial class Contact
{
    public Guid Id { get; set; }

    public long? CellNumber { get; set; }

    public string? EmailAddress { get; set; }

    public Guid? PersonId { get; set; }

    public virtual Person? Person { get; set; }
}
