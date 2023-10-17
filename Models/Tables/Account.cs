using System;
using System.Collections.Generic;

namespace CourseWork.Models.Tables;

public partial class Account
{
    public int Idaccount { get; set; }

    public int? Idemployee { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Employee? IdemployeeNavigation { get; set; }
}
