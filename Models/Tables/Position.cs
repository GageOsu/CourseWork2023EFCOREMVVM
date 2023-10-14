using System;
using System.Collections.Generic;

namespace CourseWork.Models.Tables;

public partial class Position
{
    public int Idposition { get; set; }

    public string Position1 { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
