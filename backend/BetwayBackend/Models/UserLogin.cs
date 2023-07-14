using System;
using System.Collections.Generic;

namespace BackendSolution.Models;

public partial class UserLogin
{
    public Guid Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public Guid? PersonId { get; set; }

    public virtual Person IdNavigation { get; set; } = null!;

    public virtual Otptoken? Otptoken { get; set; }

    public virtual Person? Person { get; set; }
}
