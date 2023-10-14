using System;
using System.Collections.Generic;

namespace CourseWork.Models.Tables;

public partial class InsurancePolicy
{
    public int IdinsurancePolicy { get; set; }

    public string NameInsuranceCompany { get; set; } = null!;

    public string MhipolicyNumber { get; set; } = null!;
}
