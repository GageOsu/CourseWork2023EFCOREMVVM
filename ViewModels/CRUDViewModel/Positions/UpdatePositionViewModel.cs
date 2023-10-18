using CourseWork.Infrastructure.Commands;
using CourseWork.Models.Data;
using CourseWork.Models.Tables;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels.CRUDViewModel.Positions
{
    internal class UpdatePositionViewModel : TitleViewModel
    {
        public Position PositionSelectetTabItem { get; set; }
        CRUDPositions _CRUDPosition = new CRUDPositions();


        private LambdaCommand? _updatePosition;

        public ICommand UpdatePosition => _updatePosition ??= new(_updatePositionExecuted);

        public void _updatePositionExecuted()
        {
            _CRUDPosition.UpdatePosition(PositionSelectetTabItem);
        }


        public UpdatePositionViewModel()
        {
            Title = "Изменение Должности";
            PositionSelectetTabItem = MainWindowViewModel.SelectedPosition;
        }
    }
}