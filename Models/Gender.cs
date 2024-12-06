using System;
using System.Collections.Generic;

namespace LernSchool.Models;

public partial class Gender
{
    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
