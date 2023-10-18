using CourseWork.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public bool CreateRegistrationServices(Employee employee, Patient patient, Models.Tables.TypeService typeService, int countServices, DateTime DateRegistration, DateTime DateOfService)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                try
                {
                    RegistrationService AddRegistrationService = new RegistrationService
                    {
                        Idemployee = employee.Idemployee,
                        Idpatient = patient.Idpatient,
                        Idservice = typeService.Idservice,
                        CountServices = countServices,
                        Price = countServices * typeService.PriceService,
                        DateRegistration = DateRegistration,
                        DateOfService = DateOfService,
                    };
                    db.RegistrationServices.Add(AddRegistrationService);
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при создание записи");
                    result = false;
                }
            }
            return result;
        }

        public bool UpdateRegistrationServices(RegistrationService newRegistrationService)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                RegistrationService OldRegistrationService = db.RegistrationServices.FirstOrDefault(p => p.IdserviceRegistration == newRegistrationService.IdserviceRegistration);
                {
                    OldRegistrationService.Idemployee = newRegistrationService.IdemployeeNavigation.Idemployee;
                    OldRegistrationService.Idpatient = newRegistrationService.IdpatientNavigation.Idpatient;
                    OldRegistrationService.Idservice = newRegistrationService.IdserviceNavigation.Idservice;
                    OldRegistrationService.CountServices = newRegistrationService.CountServices;
                    OldRegistrationService.Price = newRegistrationService.CountServices * newRegistrationService.IdserviceNavigation.PriceService;
                    OldRegistrationService.DateRegistration = newRegistrationService.DateRegistration;
                    OldRegistrationService.DateOfService = newRegistrationService.DateOfService;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public bool DeleteRegistrationServices(RegistrationService registrationService)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                db.RegistrationServices.Remove(registrationService);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }

}
