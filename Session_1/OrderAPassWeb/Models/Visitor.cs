using System;
using System.Collections.Generic;

namespace Models;

public partial class Visitor
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? NumberPhone { get; set; }

    public string? EMail { get; set; }

    public string? DateOfBirth { get; set; }

    public string? DataOfPasport { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}
