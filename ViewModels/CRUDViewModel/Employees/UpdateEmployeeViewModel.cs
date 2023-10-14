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
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Middlename
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value;
                OnPropertyChanged(nameof(Middlename));
            }
        }
        public Position Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
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
