using CourseWork.Infrastructure.Commands;
using CourseWork.Models.Data;
using CourseWork.Models.Tables;
using CourseWork.Services;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels.CRUDViewModel.Positions
{
    internal class CreatePositionViewModel :TitleViewModel
    {
        private string _position;
        public string Position
        {
            get => _position;
            set => Set(ref _position, value);
        }
        private WorkUser _workUser;
        private CRUDPositions _CRUDPositions = new CRUDPositions();


        private LambdaCommand? _createPosition;

        public ICommand CreatePosition => _createPosition ??= new(_createCategoryExecuted);

        public void _createCategoryExecuted()
        {
            _CRUDPositions.CreatePosition(Position);
        }

        public CreatePositionViewModel()
        {
            Title = "Создание Должности";
        }
    }
}
