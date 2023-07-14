using System;
using System.Collections.Generic;

namespace BackendSolution.Models;

public partial class Otptoken
{
    public Guid Id { get; set; }

    public string? Token { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public virtual UserLogin IdNavigation { get; set; } = null!;
}
