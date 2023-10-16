using CourseWork.Infrastructure.Commands;
using CourseWork.Models;
using CourseWork.Models.Data;
using CourseWork.Models.Table;
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
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Category> _categories;
        private ObservableCollection<Patient> _petients; 
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
        }
        #endregion




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
            SelectedEmployees = new Employee();
            SelectedCategories = new Category();
        }

    }
}
