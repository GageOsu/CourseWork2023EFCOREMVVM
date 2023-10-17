using CourseWork.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork.Models.Data
{
    internal class CRUDPatients
    {
        public ObservableCollection<Patient> ReadPatient()
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                var patient = new ObservableCollection<Patient>(db.Patients.Include(u => u.IdadressesNavigation).Include(c => c.IdinsurancePolicyNavigation));
                return patient;
            }
        }

        public bool CreatePatient(string nameIncuranceCompany, string MHIPolicyNumber, string postalCode, 
            string typeSubject, string nameSubject, string typeLocality, string locality, string typeSettlement, 
            string settlement, string typeLocation, string location,string houseNumber, string structure, 
            string building, string flat,string passportNumber, string snilsNumber,  string surname, 
            string name, string middleName, DateTime dateBrith,string sex, string phoneNumber)
        {
            bool result = false;

            
                using (StomatologicClinicContext db = new StomatologicClinicContext())
                {
                    InsurancePolicy newInsurancePolicy = new InsurancePolicy
                    {
                        NameInsuranceCompany = nameIncuranceCompany,
                        MhipolicyNumber = MHIPolicyNumber,
                    };
                    db.InsurancePolicies.Add(newInsurancePolicy);
                    db.SaveChanges();
                    Address newAddress = new Address
                    {
                        PostalCode = postalCode,
                        TypeSubject = typeSubject,
                        NameSubject = nameSubject,
                        TypeLocality = typeLocality,
                        Locality = locality,
                        TypeSettlement = typeSettlement,
                        Settlement = settlement,
                        TypeLocation = typeLocation,
                        Location = location,
                        HouseNumber = houseNumber,
                        Structure = structure,
                        Building = building,
                        Flat = flat,
                    };
                    db.Addresses.Add(newAddress);
                    db.SaveChanges();
                    Patient newPatient = new Patient
                    {
                        IdinsurancePolicy = newInsurancePolicy.IdinsurancePolicy,
                        Idadresses = newAddress.Idadresses,
                        PassportNumber = passportNumber,
                        SnilsNumber = snilsNumber,
                        Surname = surname,
                        Name = name,
                        MiddleName = middleName,
                        DateBrith = dateBrith,
                        Sex = sex,
                        PhoneNumber = phoneNumber,
                    };
                    db.Patients.Add(newPatient);
                    db.SaveChanges();

                result = true;
            }
            return result;
        }


        public  bool UpdatePatient(Patient newPatient)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                try
                {

                    InsurancePolicy oldInsurancePolicy = db.InsurancePolicies.FirstOrDefault(p => p.IdinsurancePolicy == newPatient.IdinsurancePolicy);
                    {
                        oldInsurancePolicy.NameInsuranceCompany = newPatient.IdinsurancePolicyNavigation.NameInsuranceCompany;
                        oldInsurancePolicy.MhipolicyNumber = newPatient.IdinsurancePolicyNavigation.MhipolicyNumber;
                        db.SaveChanges();
                    }
                    Address oldAdress = db.Addresses.FirstOrDefault(p => p.Idadresses == newPatient.Idadresses);
                    {
                        oldAdress.PostalCode = newPatient.IdadressesNavigation.PostalCode;
                        oldAdress.TypeSubject = newPatient.IdadressesNavigation.TypeSubject;
                        oldAdress.NameSubject = newPatient.IdadressesNavigation.NameSubject;
                        oldAdress.TypeLocality = newPatient.IdadressesNavigation.TypeLocality;
                        oldAdress.Locality = newPatient.IdadressesNavigation.Locality;
                        oldAdress.TypeSettlement = newPatient.IdadressesNavigation.TypeSettlement;
                        oldAdress.Settlement = newPatient.IdadressesNavigation.Settlement;
                        oldAdress.TypeLocality = newPatient.IdadressesNavigation.TypeLocality;
                        oldAdress.Location = newPatient.IdadressesNavigation.Location;
                        oldAdress.HouseNumber = newPatient.IdadressesNavigation.HouseNumber;
                        oldAdress.Structure = newPatient.IdadressesNavigation.Structure;
                        oldAdress.Building = newPatient.IdadressesNavigation.Building;
                        oldAdress.Flat = newPatient.IdadressesNavigation.Flat;

                    Patient OldPatient = db.Patients.FirstOrDefault(p => p.Idpatient == newPatient.Idpatient);
                    {
                        OldPatient.PassportNumber = newPatient.PassportNumber;
                        OldPatient.SnilsNumber = newPatient.SnilsNumber;
                        OldPatient.Surname = newPatient.Surname;
                        OldPatient.Name = newPatient.Name;
                        OldPatient.MiddleName = newPatient.MiddleName;
                        OldPatient.DateBrith = newPatient.DateBrith;
                        OldPatient.Sex = newPatient.Sex;
                        OldPatient.PhoneNumber = newPatient.PhoneNumber;
                        db.SaveChanges();
                    }
                    }
                    result = true;
                }
                catch(Exception) 
                {
                    MessageBox.Show("Ошибка при обновление записи");
                    result = false;
                }
            }
            return result;
        }

        public  bool DeletePatient(Patient patient)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                try
                {
                    db.Patients.Remove(patient);
                    InsurancePolicy insurancePolicy = db.InsurancePolicies.FirstOrDefault(p => p.IdinsurancePolicy == patient.IdinsurancePolicy);
                    db.InsurancePolicies.Remove(insurancePolicy);
                    Address address = db.Addresses.FirstOrDefault(p => p.Idadresses == patient.Idadresses);
                    db.Addresses.Remove(address);
                    db.SaveChanges();
                    result = true;
                }
                catch(Exception)
                {
                    MessageBox.Show("Ошибка при удаление записи");
                    result = false;
                }
            }
            return result;
        }
    }
}
