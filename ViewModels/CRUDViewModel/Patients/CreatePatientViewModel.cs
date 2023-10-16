using CourseWork.Infrastructure.Commands;
using CourseWork.Models.Data;
using CourseWork.Services;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels.CRUDViewModel.Patients
{
    internal class CreatePatientViewModel : TitleViewModel
    {
        private string postalCode;
        private string nameSubject;
        private string locality;
        private string typeSettlement;
        private string settlement;
        private string typeLocation;
        private string location;
        private string houseNumber;
        private string structure;
        private string building;
        private string flat;
        private string typeLocalityString;
        private string typeSubjectString;
        private List<String> typeLocality = new List<string> { "Город", "Городской поселок", "Деревня", "Село", "Станция", "Аул", "Хутор", "Кишлак" };
        private List<String> typeSubject = new List<string> { "Республика", "Край", "Область", "Город федерального значения", "Автономная область", "Автономный округ" };
        private string nameInsuranceCompany;
        private string mhiPolicyNumber;
        private string passportNumber;
        private string snilsNumber;
        private string surname;
        private string name;
        private string middleName;
        DateTime dateBrith;
        private string sexString;
        private List<string> sex = new List<string>() { "МУЖ", "ЖЕН" };
        private string phoneNumber;
        public CRUDPatients _CRUDPatients = new CRUDPatients();
        private IWorkUser _workUser;
        public string PostalCode
        {
            get => postalCode;
            set => Set(ref postalCode,value);
        }
        public string NameSubject
        {
            get => nameSubject;
            set => Set(ref nameSubject,value);
        }
        public string Locality
        {
            get => locality; 
            set => Set(ref locality, value);
        }
        public string TypeSettlement
        {
            get => typeSettlement; 
            set => Set(ref typeSettlement, value);
        }
        public string Settlement
        {
            get => settlement; 
            set => Set(ref settlement, value);
        }
        public string TypeLocation
        {
            get => typeLocation; 
            set => Set(ref typeLocation, value);
        }
        public string Location
        {
            get => location; 
            set => Set(ref location, value);
        }
        public string HouseNumber
        {
            get => houseNumber; 
            set => Set(ref houseNumber, value);
        }
        public string Structure
        {
            get => structure; 
            set => Set(ref structure, value);
        }
        public string Building
        {
            get => building; 
            set => Set(ref building, value);
        }
        public string Flat
        {
            get => flat; 
            set => Set(ref flat, value);
        }
        public List<String> TypeLocality
        {
            get => typeLocality;
            set => Set(ref typeLocality, value);
        }
        public List<String> TypeSubject
        {
            get => typeSubject; 
            set => Set(ref typeSubject, value);
        }
        public string TypeLocalityString
        {
            get => typeLocalityString;
            set => Set(ref typeLocalityString, value);
        }
        public string TypeSubjectString
        {
            get => typeSubjectString;
            set => Set(ref typeSubjectString, value);
        }
        public string NameInsuranceCompany
        {
            get => nameInsuranceCompany;
            set => Set(ref nameInsuranceCompany, value);
        }
        public string MHIPolicyNumber
        {
            get => mhiPolicyNumber;
            set => Set(ref mhiPolicyNumber, value);
        }
        public string PassportHumber
        {
            get => passportNumber;
            set => Set(ref  passportNumber, value);
        }
        public string SnilsNumber
        {
            get => snilsNumber; 
            set => Set(ref snilsNumber, value);
        }
        public string Surname
        {
            get => surname; 
            set => Set(ref surname, value);
        }
        public string Name
        {
            get => name; 
            set => Set(ref name, value);
        }
        public string MiddleName
        {
            get => middleName;
            set => Set(ref middleName, value);
        }
        public DateTime DateBrith
        {
            get => dateBrith;
            set => Set(ref dateBrith, value);
        }
        public string SexString
        {
            get => sexString; 
            set => Set(ref sexString, value);
        }
        public List<String> Sex
        {
            get => sex;
            set => Set(ref sex, value);
        }
        public string PhoneNumber
        {
            get => phoneNumber; 
            set => Set(ref phoneNumber, value);
        }


        private LambdaCommand? _createPatient;

        public ICommand CreatePatient => _createPatient ??= new(_createPatientsExecuted);

        public void _createPatientsExecuted()
        {
            _CRUDPatients.CreatePatient(nameInsuranceCompany,MHIPolicyNumber,PostalCode,
                TypeSubjectString,NameSubject,typeLocalityString,Locality,TypeSettlement,
                Settlement,TypeLocation,location,HouseNumber,Structure,Building,Flat,
                PassportHumber,SnilsNumber,Surname,Name,MiddleName,DateBrith,SexString,
                PhoneNumber);
        }

        public CreatePatientViewModel()
        {
            Title = "Запись Пациента";
        }

        public CreatePatientViewModel(WorkUser workUser) : this()
        {
            _workUser = workUser;
        }


    }
}
