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

namespace CourseWork.ViewModels.CRUDViewModel.Employees
{
    internal class UpdateEmployeeViewModel : TitleViewModel
    {
        MainWindowViewModel _MainWindowViewModel = new MainWindowViewModel();

        CRUDPositions _CRUDPositions = new CRUDPositions();
        CRUDEmployees _CRUDEmployees = new CRUDEmployees();

        public Employee EmployeeSelectedItem { get; set; }

        public ObservableCollection<Position> Positions { get; set; }


        private LambdaCommand? _updateEmployees;

        public ICommand UpdateEmployees => _updateEmployees ??= new(_updateEmployeesExecuted);

        public void _updateEmployeesExecuted()
        {
            _CRUDEmployees.UpdateEmployee(EmployeeSelectedItem);
        }


        public UpdateEmployeeViewModel() 
        {
            Title = "Изменение сотрудника";
            EmployeeSelectedItem = MainWindowViewModel.SelectedEmployees;
            Positions = new ObservableCollection<Position>(_CRUDPositions.ReadPositions());
        }



    }
}
