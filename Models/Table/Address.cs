using System;
using System.Collections.Generic;

namespace CourseWork.Models.Table;

public partial class Address
{
    public int Idadresses { get; set; }

    public string? PostalCode { get; set; }

    public string TypeSubject { get; set; } = null!;

    public string NameSubject { get; set; } = null!;

    public string TypeLocality { get; set; } = null!;

    public string? Locality { get; set; }

    public string? TypeSettlement { get; set; }

    public string? Settlement { get; set; }

    public string? TypeLocation { get; set; }

    public string? Location { get; set; }

    public string? HouseNumber { get; set; }

    public string? Structure { get; set; }

    public string? Building { get; set; }

    public string? Flat { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
