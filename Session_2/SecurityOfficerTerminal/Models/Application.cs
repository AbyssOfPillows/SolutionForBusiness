using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models;

public partial class Application
{
    public int Id { get; set; }

    public DateTime? DateOfVisit { get; set; }

    public int EmployeeId { get; set; }

    public int GroupId { get; set; }

    public string Purpose { get; set; } = null!;

    public DateTime? DesiredStartDate { get; set; }

    public DateTime? DesiredEndDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
