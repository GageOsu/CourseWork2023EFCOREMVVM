using CourseWork.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models.Data
{
    internal class CRUDServicePriceHistories
    {
        public ObservableCollection<ServicePriceHistory> ReadServicePriceHistories()
        {
            using(StomatologicClinicContext db = new StomatologicClinicContext())
            {
                var servicePriceHistories = new ObservableCollection<ServicePriceHistory>(db.ServicePriceHistories.Include(p => p.IdserviceNavigation));
                return servicePriceHistories;
            }
        }
    }
}
