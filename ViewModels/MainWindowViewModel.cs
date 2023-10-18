using CourseWork.Infrastructure.Commands;
using CourseWork.Models;
using CourseWork.Models.Data;
using CourseWork.Models.Tables;
using CourseWork.Services;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseWork.ViewModels
{
    internal class MainWindowViewModel : TitleViewModel
    {
        CRUDEmployees CRUDEmployees = new CRUDEmployees();
        CRUDCategories _CRUDCategories = new CRUDCategories();
        CRUDPatients _CRUDPatients = new CRUDPatients();
        CRUDPositions _CRUDPositions = new CRUDPositions();
        CRUDTypeService _CRUDTypeService = new CRUDTypeService();
        CRUDServicePriceHistories _CRUDServicePriceHistories = new CRUDServicePriceHistories();
        CRUDRegistrationServices _CRUDRegistrationServices = new CRUDRegistrationServices();
        private ObservableCollection<ServicePriceHistory> _servicePriceHistories;
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Category> _categories;
        private ObservableCollection<Patient> _petients; 
        private ObservableCollection<Position> _positions;
        private ObservableCollection<TypeService> _typeService;
        private ObservableCollection<RegistrationService> _registrationServices;
        public ObservableCollection<Employee> Employees 
        {
            get => _employees;
            set => Set(ref _employees, value);
        }

        public ObservableCollection<Category> Catigories
        {
            get => _categories;
            set => Set(ref _categories, value);
        }
        public ObservableCollection<Patient> Patients
        {
            get => _petients;
            set => Set(ref _petients, value);
        }
        public ObservableCollection<Position> Positions
        {
            get => _positions;
            set => Set(ref _positions, value);
        }
        public ObservableCollection<TypeService> TypeServices
        {
            get => _typeService;
            set => Set(ref _typeService, value);
        }
        public ObservableCollection<ServicePriceHistory> ServicePriceHistories
        {
            get => _servicePriceHistories;
            set => Set(ref _servicePriceHistories, value);
        }

        public ObservableCollection<RegistrationService> RegistrationServices
        {
            get => _registrationServices;
            set => Set(ref _registrationServices, value);
        }

        #region Выбор нужной строки
        public TabItem SelectedTabItem { get; set; }

        private static Employee _selectedEmployees;
        public static Employee SelectedEmployees
        {
            get => _selectedEmployees;
            set => _selectedEmployees = value;
        }

        private static Category _selectedCategories;
        public static Category SelectedCategories
        {
            get => _selectedCategories;
            set => _selectedCategories = value;
        }

        private static Patient _selectedPatients;
        public static Patient SelectedPatients
        {
            get => _selectedPatients;
            set => _selectedPatients = value;
        }

        private static Position _selectedPosition;
        public static Position SelectedPosition
        {
            get => _selectedPosition;
            set => _selectedPosition = value;
        }

        private static TypeService _selectedTypeService;
        public static TypeService SelectedTypeService
        {
            get => _selectedTypeService;
            set => _selectedTypeService = value;
        }
        private static RegistrationService _selectedRegistrationService;
        public static RegistrationService SelectedRegistrationService
        {
            get => _selectedRegistrationService;
            set => _selectedRegistrationService = value;
        }

        #endregion

        #region Открытия окон 
        #region Окна для Employees

        private LambdaCommand? _openCreateWindowCommand;
        public ICommand OpenCreateWindowCommand => _openCreateWindowCommand ??= new(_onOpenCreateWindowCommandExecuted);
        private void _onOpenCreateWindowCommandExecuted()
        {
            _workUser.OpenCreateWindow();
        }

        private LambdaCommand? _openUpdateEmployeeCommand;
        public ICommand OpenUpdateEmployeeCommand => _openUpdateEmployeeCommand ??= new(_onOpenCreateWindowCommandExecuted);
        private void _onOpenUpdateEmployeeCommand()
        {
            _workUser.OpenUpdateEmployeeWindow();
        }
        #endregion

        #region Окна для Categories

        private LambdaCommand? _openCreateCategoriesWindowCommand;
        public ICommand OpenCreateCategoriesWindowCommand => _openCreateCategoriesWindowCommand ??= new(_onOpenCreateCategoriesWindowCommandExecuted);
        private void _onOpenCreateCategoriesWindowCommandExecuted()
        {
            _workUser.OpenCreateCategoryWindow();
        }

        private LambdaCommand? _openUpdateCategoriesWindowCommand;
        public ICommand OpenUpdateCategoriesWindowCommand => _openUpdateCategoriesWindowCommand ??= new(_onOpenUpdateCategoriesWindowCommandExecuted);
        private void _onOpenUpdateCategoriesWindowCommandExecuted()
        {
            _workUser.OpenUpdateCategoryWindow();
        }
        #endregion

        #region 
        private LambdaCommand? _openCreatePatientWindowCommand;
        public ICommand OpenCreatePatientCommand => _openCreatePatientWindowCommand ??= new(_onOpenCreatePatientWindowCommandExecuted);
        private void _onOpenCreatePatientWindowCommandExecuted()
        {
            _workUser.OpenCreatePatientWindow();
        }

        private LambdaCommand? _openUpdatePatientWindowCommand;
        public ICommand OpenUpdatePatientCommand => _openUpdatePatientWindowCommand ??= new(_onOpenUpdatePatientWindowCommandExecuted);
        private void _onOpenUpdatePatientWindowCommandExecuted()
        {
            _workUser.OpenUpdatePatientWindow();
        }

        private LambdaCommand? _openCreatePositionWindowCommand;
        public ICommand OpenCreatePositionWindowCommand => _openCreatePositionWindowCommand ??= new(_onOpenCreatePositionWindowCommandExecuted);
        private void _onOpenCreatePositionWindowCommandExecuted()
        {
            _workUser.OpenCreatePositionWindow();
        }

        private LambdaCommand? _onOpenUpdatePositionWindowCommand;
        public ICommand OpenUpdatePositionWindowCommand => _onOpenUpdatePositionWindowCommand ??= new(_onOpenUpdatePositionWindowCommandExecuted);
        private void _onOpenUpdatePositionWindowCommandExecuted()
        {
            _workUser.OpenUpdatePositionWindow();
        }

        private LambdaCommand? _onOpenCreateTypeServiceWindowCommand;
        public ICommand OpenCreateTypeServiceWindowCommand => _onOpenCreateTypeServiceWindowCommand ??= new(_onOpenCreateTypeServiceWindowCommandExecuted);
        private void _onOpenCreateTypeServiceWindowCommandExecuted()
        {
            _workUser.OpenCreateTypeServiceWindow();
        }

        private LambdaCommand? _onOpenUpdateTypeServiceWindowCommand;
        public ICommand OpenUpdateTypeServiceWindowCommand => _onOpenUpdateTypeServiceWindowCommand ??= new(_onOpenUpdateTypeServiceWindowCommandExecuted);
        private void _onOpenUpdateTypeServiceWindowCommandExecuted()
        {
            _workUser.OpenUpdateTypeServiceWindow();
        }

        private LambdaCommand? _onOpenCreateRegistrationWindowCommand;
        public ICommand OpenCreateRegistrationWindowCommandCommand => _onOpenCreateRegistrationWindowCommand ??= new(_onOpenCreateRegistrationWindowCommandCommandExecuted);
        private void _onOpenCreateRegistrationWindowCommandCommandExecuted()
        {
            _workUser.OpenCreateRegistrationWindow();
        }

        private LambdaCommand? _onOpenUpdateRegistrationWindowCommand;
        public ICommand OpenUpdateRegistrationWindowCommandCommand => _onOpenUpdateRegistrationWindowCommand ??= new(_onOpenUpdateRegistrationWindowCommandCommandExecuted);
        private void _onOpenUpdateRegistrationWindowCommandCommandExecuted()
        {
            _workUser.OpenUpdateRegistrationWindow();
        }
        #endregion

        #endregion


        #region Удаление выбранной строчки
        private LambdaCommand? _deleteItem;
        public ICommand DeleteItem => _deleteItem ??= new(_deleteItemCommandExecuted);

        public void _deleteItemCommandExecuted()
        {
            if(SelectedTabItem.Name == "EmployeesTab" && SelectedEmployees != null)
            {
                CRUDEmployees.DeleteEmployee(SelectedEmployees);
                Employees = CRUDEmployees.ReadEmployes();
            }
            if(SelectedTabItem.Name == "CategoriesTab" && SelectedCategories != null)
            {
                _CRUDCategories.DeleteCategory(SelectedCategories);
                Catigories = _CRUDCategories.ReadCatigories();
            }
            if(SelectedTabItem.Name == "PatientsTab" && SelectedPatients != null)
            {
                _CRUDPatients.DeletePatient(SelectedPatients);
                Patients = _CRUDPatients.ReadPatient();
            }
            if(SelectedTabItem.Name == "PositionsTab" && SelectedPosition != null)
            {
                _CRUDPositions.DeletePosition(SelectedPosition);
                Positions = _CRUDPositions.ReadPositions();
            }
            if (SelectedTabItem.Name == "TypeServicesTab" && SelectedTypeService != null)
            {
                _CRUDTypeService.DeleteTypeService(SelectedTypeService);
                TypeServices = _CRUDTypeService.ReadTypeServices();
            }
            if (SelectedTabItem.Name == "RegistrationServiceTab" && SelectedRegistrationService != null)
            {
                _CRUDRegistrationServices.DeleteRegistrationServices(SelectedRegistrationService);
                RegistrationServices = _CRUDRegistrationServices.ReadRegistrationServices();
            }
        }
        #endregion

        #region Открытия окно для Изменения таблиц
        private LambdaCommand? _updateItem;
        public ICommand UpdateItem => _updateItem ??= new(_updateItemCommandExecuted);

        public void _updateItemCommandExecuted()
        {
            if (SelectedTabItem.Name == "EmployeesTab" && SelectedEmployees != null)
            {
                _onOpenUpdateEmployeeCommand();
            }
            if (SelectedTabItem.Name == "CategoriesTab" && SelectedCategories != null)
            {
                _onOpenUpdateCategoriesWindowCommandExecuted();
            }
            if (SelectedTabItem.Name == "PatientsTab" && SelectedPatients != null)
            {
                _onOpenUpdatePatientWindowCommandExecuted();
            }
            if (SelectedTabItem.Name == "PositionsTab" && SelectedPosition != null)
            {
                _onOpenUpdatePositionWindowCommandExecuted();
            }
            if (SelectedTabItem.Name == "TypeServicesTab" && SelectedTypeService != null)
            {
                _onOpenUpdateTypeServiceWindowCommandExecuted();
            }
            if (SelectedTabItem.Name == "RegistrationServiceTab" && SelectedRegistrationService != null)
            {
                _onOpenUpdateRegistrationWindowCommandCommandExecuted();
            }
        }
        #endregion

        private LambdaCommand? _onLoadAllCommand;
        public ICommand LoadAllCommand => _onLoadAllCommand ??= new(_onLoadAllCommandExecuted);
        private void _onLoadAllCommandExecuted()
        {
            Employees = new ObservableCollection<Employee>(CRUDEmployees.ReadEmployes());
            Catigories = new ObservableCollection<Category>(_CRUDCategories.ReadCatigories());
            Patients = new ObservableCollection<Patient>(_CRUDPatients.ReadPatient());
            Positions = new ObservableCollection<Position>(_CRUDPositions.ReadPositions());
            TypeServices = new ObservableCollection<TypeService>(_CRUDTypeService.ReadTypeServices());
            ServicePriceHistories = new ObservableCollection<ServicePriceHistory>(_CRUDServicePriceHistories.ReadServicePriceHistories());
            RegistrationServices = new ObservableCollection<RegistrationService>(_CRUDRegistrationServices.ReadRegistrationServices());
        }


        private readonly IWorkUser _workUser;
        public MainWindowViewModel()
        {
            Title = "Главное окно";

        }

        public MainWindowViewModel(IWorkUser WorkUser) : this()
        {
            _workUser = WorkUser;
            Employees = new ObservableCollection<Employee>(CRUDEmployees.ReadEmployes());
            Catigories = new ObservableCollection<Category>(_CRUDCategories.ReadCatigories());
            Patients = new ObservableCollection<Patient>(_CRUDPatients.ReadPatient());
            Positions = new ObservableCollection<Position>(_CRUDPositions.ReadPositions());
            TypeServices = new ObservableCollection<TypeService>(_CRUDTypeService.ReadTypeServices());
            ServicePriceHistories = new ObservableCollection<ServicePriceHistory>(_CRUDServicePriceHistories.ReadServicePriceHistories());
            RegistrationServices = new ObservableCollection<RegistrationService>(_CRUDRegistrationServices.ReadRegistrationServices());
            SelectedEmployees = new Employee();
            SelectedCategories = new Category();
            SelectedPosition = new Position();
            SelectedTypeService = new TypeService();
            SelectedRegistrationService = new RegistrationService();
        }

    }
}
