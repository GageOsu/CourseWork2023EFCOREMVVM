using System;
using System.Collections.Generic;

namespace CourseWork.Models.Tables;

public partial class ServicePriceHistory
{
    public int IdpriceHistory { get; set; }

    public int? Idservice { get; set; }

    public decimal? OldPrice { get; set; }

    public decimal? NewPrice { get; set; }

    public DateTime? DatePriceChange { get; set; }

    public virtual TypeService? IdserviceNavigation { get; set; }
}
