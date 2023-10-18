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
    internal class CRUDRegistrationServices
    {
        public ObservableCollection<RegistrationService> ReadRegistrationServices()
        {
            using (StomatologicClinicContext db =  new StomatologicClinicContext())
            {
                var registrationServices = new ObservableCollection<RegistrationService>(db.RegistrationServices.Include(p => p.IdserviceNavigation).
                    Include(p => p.IdpatientNavigation).
                    Include(p => p.IdemployeeNavigation).
                    Include(p => p.IdemployeeNavigation.IdpositionNavigation));
                return registrationServices;
            }
        }
    }
}
