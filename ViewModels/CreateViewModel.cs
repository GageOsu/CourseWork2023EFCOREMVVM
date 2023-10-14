using CourseWork.Infrastructure.Commands;
using CourseWork.Services;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels
{
    internal class CreateViewModel : TitleViewModel
    {

        private readonly IWorkUser _workUser;
       
        public CreateViewModel() 
        {
            Title = "Второек окно";
        }

        public CreateViewModel(IWorkUser workUser) : this()
        {
            _workUser = workUser;
        }

        private LambdaCommand? _openMainWindowCommand;

        public ICommand OpenMainWindowCommand => _openMainWindowCommand ??= new(_onOpenMianWindowCommandExecuted);

        private void _onOpenMianWindowCommandExecuted()
        {

        }
    }
}
