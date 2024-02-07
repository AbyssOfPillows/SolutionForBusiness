using System;
using System.Collections.Generic;

namespace UsersIBServiceTerminal.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? Sex { get; set; }

    public int? PostId { get; set; }

    public int? UserTypeId { get; set; }

    public string? SecretWord { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public bool? Approved { get; set; }

    public bool? Add { get; set; }

    public bool? Read { get; set; }

    public bool? Search { get; set; }

    public virtual Post? Post { get; set; }

    public virtual UserType? UserType { get; set; }
}
