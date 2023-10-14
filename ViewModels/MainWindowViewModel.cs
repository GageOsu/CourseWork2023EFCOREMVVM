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
        public ObservableCollection<Employee> Employees { get; set; }
        CRUDEmployees CRUDEmployees = new CRUDEmployees();
        private readonly IWorkUser _workUser;
        public TabItem SelectedTabItem { get; set; }

        private static Employee _selectedEmployees;
        public static Employee SelectedEmployees
        {
            get
            {
                return _selectedEmployees;
            }
            set
            {
                _selectedEmployees = value;
            }
        }


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



        private LambdaCommand? _deleteItem;

        public ICommand DeleteItem => _deleteItem ??= new(_deleteItemCommandExecuted);

        public void _deleteItemCommandExecuted()
        {
            if(SelectedTabItem.Name == "EmployeesTab" && SelectedEmployees != null)
            {
                CRUDEmployees.DeleteEmployee(SelectedEmployees);
            }
        }

        private LambdaCommand? _updateItem;
        public ICommand UpdateItem => _updateItem ??= new(_updateItemCommandExecuted);

        public void _updateItemCommandExecuted()
        {
            if (SelectedTabItem.Name == "EmployeesTab" && SelectedEmployees != null)
            {
                _onOpenUpdateEmployeeCommand();
            }
        }























        public MainWindowViewModel()
        {
            Title = "Главное окно";
        }

        public MainWindowViewModel(IWorkUser WorkUser) : this()
        {
            _workUser = WorkUser;
            Employees = new ObservableCollection<Employee>(CRUDEmployees.ReadEmployes());
        }

    }
}
