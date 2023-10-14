using CourseWork.Infrastructure.Commands;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels
{
    internal class MainWindowViewModel : TitleViewModel
    {
        public MainWindowViewModel() 
        {
            Title = "Главное окно";
        }

        private LambdaCommand? _openCreateWindowCommand;

        public ICommand OpenCreateWindowCommand => _openCreateWindowCommand ??= new(_onOpenCreateWindowCommandExecuted);

        private void _onOpenCreateWindowCommandExecuted()
        {

        }
    }
}
