using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Log
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public DateTime ArrivalTime { get; set; }

    public DateTime DeaprtureTime { get; set; }

    public bool Access { get; set; }

    public virtual Application Application { get; set; } = null!;
}
