using System;
using System.Collections.Generic;

namespace CourseWork.Models.Table;

public partial class RegistrationService
{
    public int IdserviceRegistration { get; set; }

    public int? Idemployee { get; set; }

    public int? Idpatient { get; set; }

    public int? Idservice { get; set; }

    public int? CountServices { get; set; }

    public decimal? Price { get; set; }

    public DateTime? DateRegistration { get; set; }

    public DateTime? DateOfService { get; set; }

    public virtual Patient? IdpatientNavigation { get; set; }

    public virtual TypeService? IdserviceNavigation { get; set; }

    public virtual Employee IdserviceRegistrationNavigation { get; set; } = null!;
}
