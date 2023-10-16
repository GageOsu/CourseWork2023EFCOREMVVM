using System;
using System.Collections.Generic;

namespace CourseWork.Models.Table;

public partial class Employee
{
    public int Idemployee { get; set; }

    public int? Idposition { get; set; }

    public string SurnameEmployee { get; set; } = null!;

    public string NameEmployee { get; set; } = null!;

    public string? MiddleNameEmployee { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Position? IdpositionNavigation { get; set; }

    public virtual RegistrationService? RegistrationService { get; set; }
}
