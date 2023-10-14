using CourseWork.Infrastructure.Commands;
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
using System.Windows.Input;

namespace CourseWork.ViewModels.CRUDViewModel.Employees
{
    internal class CreateEmployeeViewModel : TitleViewModel
    {

        private readonly IWorkUser _workUser;

        MainWindowViewModel zxc = new MainWindowViewModel();
        private CRUDPositions _CRUDPositions = new CRUDPositions();
        private CRUDEmployees _CRUDEmployees = new CRUDEmployees();
        private string _surname;
        private string _name;
        private string _middlename;
        private Position _position;
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
        public ObservableCollection<Position> Positions { get; set; }

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


        private LambdaCommand? _openMainWindowCommand;

        public ICommand OpenMainWindowCommand => _openMainWindowCommand ??= new(_onOpenMianWindowCommandExecuted);

        private void _onOpenMianWindowCommandExecuted()
        {
            _workUser.OpenMainWindow();
        }


        private LambdaCommand? _createEmployees;

        public ICommand CreateEmployees => _createEmployees ??= new(_createEmployeesExecuted);

        public void _createEmployeesExecuted()
        {
            _CRUDEmployees.CreateEmployes(Surname, Name, Middlename, Position);
            zxc.Employees = _CRUDEmployees.ReadEmployes();
        }



        #region Титл
        public CreateEmployeeViewModel()
        {
            Title = "Второек окно";
        }
        #endregion

        public CreateEmployeeViewModel(IWorkUser workUser) : this()
        {
            _workUser = workUser;
            Positions = new ObservableCollection<Position>(_CRUDPositions.ReadPositions());
        }


    }
}
