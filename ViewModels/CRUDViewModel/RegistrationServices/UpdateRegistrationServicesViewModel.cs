using CourseWork.Infrastructure.Commands;
using CourseWork.Models.Data;
using CourseWork.Models.Tables;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels.CRUDViewModel.RegistrationServices
{
    internal class UpdateRegistrationServicesViewModel : TitleViewModel
    {
        public RegistrationService RegistrationServiceSelectetTabItem { get; set; }
        CRUDRegistrationServices _CRUDRegistrationServices = new CRUDRegistrationServices();
        CRUDEmployees _CRUDEmployees = new CRUDEmployees();
        CRUDPatients _CRUDPatients = new CRUDPatients();
        CRUDTypeService _CRUDTypeService = new CRUDTypeService();
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Patient> _patients;
        private ObservableCollection<Models.Tables.TypeService> _typeServices;
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

        private LambdaCommand? _updateRegistrationService;

        public ICommand UpdateRegistrationService => _updateRegistrationService ??= new(_updateRegistrationServiceExecuted);

        public void _updateRegistrationServiceExecuted()
        {
            _CRUDRegistrationServices.UpdateRegistrationServices(RegistrationServiceSelectetTabItem);
        }

        public UpdateRegistrationServicesViewModel()
        {
            Title = "Изменение Проведение услуги";
            RegistrationServiceSelectetTabItem = MainWindowViewModel.SelectedRegistrationService;
            Employees = new ObservableCollection<Employee>(_CRUDEmployees.ReadEmployes());
            Patients = new ObservableCollection<Patient>(_CRUDPatients.ReadPatient());
            typeServices = new ObservableCollection<Models.Tables.TypeService>(_CRUDTypeService.ReadTypeServices());
        }
    }
}
