using System;
using System.Collections.Generic;

namespace BackendSolution.Models;

public partial class Person
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual UserLogin? UserLoginIdNavigation { get; set; }

    public virtual ICollection<UserLogin> UserLoginPeople { get; set; } = new List<UserLogin>();
}
