using System;
using System.Collections.Generic;

namespace Models;

public partial class Group
{
    public int Id { get; set; }

    public string? Group1 { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
