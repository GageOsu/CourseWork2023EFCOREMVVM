using CourseWork.Infrastructure.Commands;
using CourseWork.Models.Data;
using CourseWork.Models.Tables;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels.CRUDViewModel.RegistrationServices
{
    internal class CreateRegistrationServicesViewModel : TitleViewModel
    {
        CRUDRegistrationServices _CRUDRegistrationServices = new CRUDRegistrationServices();
        CRUDEmployees _CRUDEmployees = new CRUDEmployees();
        CRUDPatients _CRUDPatients = new CRUDPatients();
        CRUDTypeService _CRUDTypeService = new CRUDTypeService();
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Patient> _patients;
        private ObservableCollection<Models.Tables.TypeService> _typeServices;
        private Employee _employee;
        private Patient _patient;
        private Models.Tables.TypeService _typeService;
        private int _countServices;
        private decimal _price;
        private DateTime _dateRegistration;
        private DateTime _dateOfService;
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }
        public ObservableCollection<Patient> Patients 
        { 
            get => _patients;
            set => Set(ref _patients, value); 
        }
        public ObservableCollection<Models.Tables.TypeService> typeServices 
        { 
            get => _typeServices; 
            set => Set(ref _typeServices, value); 
        }
        public Employee Employee
        {
            get => _employee; 
            set => Set(ref _employee, value);
        }
        public Patient Patient
        {
            get => _patient; 
            set => Set(ref _patient, value);
        }
        public Models.Tables.TypeService TypeService 
        { 
            get => _typeService; 
            set => Set(ref _typeService, value); 
        }
        public int CountServices
        {
            get => _countServices;
            set => Set(ref _countServices, value);
        }
        public DateTime DateRegistration
        {
            get => _dateRegistration; 
            set => Set(ref _dateRegistration, value);
        }
        public DateTime DateOfService
        {
            get => _dateOfService;
            set => Set(ref _dateOfService, value);
        }

        private LambdaCommand? _createRegistration;

        public ICommand CreateRegistration => _createRegistration ??= new(_createRegistrationExecuted);

        public void _createRegistrationExecuted()
        {
            _CRUDRegistrationServices.CreateRegistrationServices(Employee, Patient,TypeService,CountServices,DateRegistration,DateOfService);
        }

        public CreateRegistrationServicesViewModel()
        {
            Title = "Регистрация проведения услуги";
            Employees = new ObservableCollection<Employee>(_CRUDEmployees.ReadEmployes());
            Patients = new ObservableCollection<Patient>(_CRUDPatients.ReadPatient());
            typeServices = new ObservableCollection<Models.Tables.TypeService>(_CRUDTypeService.ReadTypeServices());
        }
    }
}
