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
        private CRUDPositions _CRUDPositions = new CRUDPositions();
        private CRUDEmployees _CRUDEmployees = new CRUDEmployees();
        private string _surname;
        private string _name;
        private string _middlename;
        private Position _position;
        public Position Position
        {
            get => _position;
            set => Set(ref _position, value);
        }
        public ObservableCollection<Position> Positions { get; set; }

        public string Surname
        {
            get => _surname;
            set => Set(ref _surname, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Middlename
        {
            get => _middlename;
            set => Set(ref _middlename, value);
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
        }



        #region Титл
        public CreateEmployeeViewModel()
        {
            Title = "Второек окно";

        }
        #endregion

        public CreateEmployeeViewModel(IWorkUser workUser, MainWindowViewModel mainWindowViewModel) : this()
        {
            mainWindowViewModel.Employees = _CRUDEmployees.ReadEmployes();
            _workUser = workUser;
            Positions = new ObservableCollection<Position>(_CRUDPositions.ReadPositions());
        }


    }
}
