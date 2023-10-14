using System;
using System.Collections.Generic;

namespace CourseWork.Models.Tables;

public partial class Patient
{
    public int Idpatient { get; set; }

    public int? IdinsurancePolicy { get; set; }

    public int? Idadresses { get; set; }

    public string? PassportNumber { get; set; }

    public string? SnilsNumber { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public DateTime? DateBrith { get; set; }

    public string? Sex { get; set; }

    public string? PhoneNumber { get; set; }
}
