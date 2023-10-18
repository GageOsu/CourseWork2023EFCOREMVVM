using CourseWork.Infrastructure.Commands;
using CourseWork.Models.Tables;
using CourseWork.Services;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CourseWork.ViewModels.AuthorizationViewModel
{
    internal class Authorization : TitleViewModel
    {
        private string _login;
        private string _password;
        private readonly IWorkUser _workUser;
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }
        public string Password
        {
            get => _password; 
            set => Set(ref _password, value);
        }

        private LambdaCommand? _onOpenMainWindowCommand;
        public ICommand OpenMainWindowCommandCommand => _onOpenMainWindowCommand ??= new(_onOpenMainWindowCommandCommandCommandExecuted);
        private void _onOpenMainWindowCommandCommandCommandExecuted()
        {
            if (Enter(Login, Password) == true)
            {
                _workUser.OpenMainWindow();
            }
        }

        private bool Enter(string Login, string Password)
        {
            var result = false;
            using (StomatologicClinicContext db =  new StomatologicClinicContext())
            {
                var user = db.Accounts.FirstOrDefault(x => x.Login == Login && x.Password == Password);
                if (user != null)
                {
                    result = true;
                }
                else
                {
                    MessageBox.Show("Ошибка");
                    result = false;
                }
            }
            return result;
        }

        public Authorization()
        {
            Title = "Авторизация";
        }

        public Authorization(IWorkUser workUser) : this()
        {
            _workUser = workUser;
        }
    }
}
