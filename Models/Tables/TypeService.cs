using System;
using System.Collections.Generic;

namespace CourseWork.Models.Tables;

public partial class TypeService
{
    public int Idservice { get; set; }

    public int? Idcategory { get; set; }

    public string NameService { get; set; } = null!;

    public decimal PriceService { get; set; }

    public virtual Category? IdcategoryNavigation { get; set; }

    public virtual ICollection<RegistrationService> RegistrationServices { get; set; } = new List<RegistrationService>();

    public virtual ICollection<ServicePriceHistory> ServicePriceHistories { get; set; } = new List<ServicePriceHistory>();
}
