using CourseWork.Views.CRUDView.Employee;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork.Services
{
    internal class WorkUser : IWorkUser
    {
        private readonly IServiceProvider _services;
        public WorkUser(IServiceProvider Service) => _services = Service;


        private MainWindow? _mainWindow;
        public void OpenMainWindow()
        {
            if(_mainWindow is { } window)
            {
                window.Show();
                return;
            }


            window = _services.GetRequiredService<MainWindow>();
            window.Closed += (_, _) => _mainWindow = null;

            _mainWindow = window;
            window.Show();
        }

        private CreateEmployeeWindows? _createEmployeeWindows;
        public void OpenCreateWindow()
        {
            if(_createEmployeeWindows is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<CreateEmployeeWindows>();
            window.Closed += (_, _) => _createEmployeeWindows = null;

            _createEmployeeWindows = window;
            window.Show();
        }
    }
}
