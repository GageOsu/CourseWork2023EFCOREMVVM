using System;
using System.Collections.Generic;

namespace CourseWork.Models.Table;

public partial class Category
{
    public int Idcategory { get; set; }

    public string? Category1 { get; set; }

    public virtual ICollection<TypeService> TypeServices { get; set; } = new List<TypeService>();
}
