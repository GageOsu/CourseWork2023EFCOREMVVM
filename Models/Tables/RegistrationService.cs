using System;
using System.Collections.Generic;

namespace CourseWork.Models.Tables;

public partial class RegistrationService
{
    public int IdserviceRegistration { get; set; }

    public int Idemployee { get; set; }

    public int Idpatient { get; set; }

    public int Idservice { get; set; }

    public int CountServices { get; set; }

    public decimal Price { get; set; }

    public DateTime DateRegistration { get; set; }

    public DateTime? DateOfService { get; set; }

    public virtual Employee IdemployeeNavigation { get; set; } = null!;

    public virtual Patient IdpatientNavigation { get; set; } = null!;

    public virtual TypeService IdserviceNavigation { get; set; } = null!;
}
