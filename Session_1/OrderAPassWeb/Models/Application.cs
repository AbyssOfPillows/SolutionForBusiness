using System;
using System.Collections.Generic;

namespace Models;

public partial class Application
{
    public int Id { get; set; }

    public string? DateOfVisit { get; set; }

    public int? EmployeeId { get; set; }

    public int? GroupId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Group? Group { get; set; }
}
