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
        private string _name;
        private string _surname;
        private string _middlename;
        private Position _position;
        CRUDPositions CRUDPositions = new CRUDPositions();
        public Employee EmployeeSelectedItem { get; set; }
        public ObservableCollection<Position> Positions { get; set; }


        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Surname
        {
            get => _surname;
            set => Set(ref _surname, value);
        }

        public string Middlename
        {
            get => _middlename;
            set => Set(ref _middlename, value);
        }
        public Position Position
        {
            get => _position;
            set => Set(ref _position, value);
        }





        private LambdaCommand? _updateEmployees;

        public ICommand UpdateEmployees => _updateEmployees ??= new(_updateEmployeesExecuted);

        public void _updateEmployeesExecuted()
        {
            CRUDEmployees.UpdateEmployee(EmployeeSelectedItem);
        }


        public UpdateEmployeeViewModel() 
        {
            Title = "Изменение сотрудника";
            EmployeeSelectedItem = MainWindowViewModel.SelectedEmployees;
            Positions = new ObservableCollection<Position>(CRUDPositions.ReadPositions());
        }



    }
}
