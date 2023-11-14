using System;
using System.Collections.Generic;

namespace Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? DepartmentId { get; set; }

    public int? Code { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Department? Department { get; set; }
}
