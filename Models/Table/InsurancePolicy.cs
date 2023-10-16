using System;
using System.Collections.Generic;

namespace CourseWork.Models.Table;

public partial class InsurancePolicy
{
    public int IdinsurancePolicy { get; set; }

    public string NameInsuranceCompany { get; set; } = null!;

    public string MhipolicyNumber { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
