using CourseWork.ViewModels.CRUDViewModel.Categories;
using CourseWork.Views.AuthorizationView;
using CourseWork.Views.CRUDView.Category;
using CourseWork.Views.CRUDView.Employee;
using CourseWork.Views.CRUDView.Patient;
using CourseWork.Views.CRUDView.Position;
using CourseWork.Views.CRUDView.RegistrationServices;
using CourseWork.Views.CRUDView.TypeService;
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

        private AuthorizationWindow _authorizationWindow;
        public void OpenAuthorizationWindow()
        {
            if (_authorizationWindow is { } window) 
            { 
                window.Show();
                return;
            }
            window = _services.GetRequiredService<AuthorizationWindow>();
            window.Closed += (_, _) => _authorizationWindow = null;

            _authorizationWindow = window;
            window.Show();
        }

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


        private UpdateEmployeeWindow? updateEmployeeWindow;
        public void OpenUpdateEmployeeWindow()
        {
            if (updateEmployeeWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<UpdateEmployeeWindow>();
            window.Closed += (_, _) => updateEmployeeWindow = null;

            updateEmployeeWindow = window;
            window.Show();
        }

        private CreateCategoryWindow? createCategoryWindow;
        public void OpenCreateCategoryWindow()
        {
            if(createCategoryWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<CreateCategoryWindow>();
            window.Closed += (_, _) => createCategoryWindow = null;
            createCategoryWindow = window;
            window.Show();
        }

        private UpdateCategoryWindow? updateCategoryWindow;
        public void OpenUpdateCategoryWindow()
        {
            if(updateCategoryWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<UpdateCategoryWindow>();
            window.Closed += (_, _) => updateCategoryWindow = null; 
            updateCategoryWindow = window;
            window.Show();
        }

        private CreatePatientWindow? createPatientWindow;
        public void OpenCreatePatientWindow()
        {
            if (createPatientWindow is { } window)
            {
                window.Show(); 
                return;
            }

            window = _services.GetRequiredService<CreatePatientWindow>();
            window.Closed += (_, _) => createPatientWindow = null; 
            createPatientWindow = window;
            window.Show();
        }

        private UpdatePatientWindow? updatePatientWindow;
        public void OpenUpdatePatientWindow()
        {
            if (updatePatientWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<UpdatePatientWindow>();
            window.Closed += (_, _) => updatePatientWindow = null;
            updatePatientWindow = window;
            window.Show();
        }

        private CreatePositionWindow? createPositionWindow;
        public void OpenCreatePositionWindow()
        {
            if (createPositionWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<CreatePositionWindow>();
            window.Closed += (_, _) => updatePatientWindow = null;
            createPositionWindow = window;
            window.Show();
        }

        private UpdatePositionWindow? updatePositionWindow;
        public void OpenUpdatePositionWindow()
        {
            if(updatePositionWindow is { } window)
            {
                window.Show();
                return;
            }
            window = _services.GetRequiredService<UpdatePositionWindow>();
            window.Closed -= (_, _) => updatePositionWindow = null; 
            updatePositionWindow = window;
            window.Show();
        }

        private CreateTypeServicesWindow? createTypeServicesWindow;
        public void OpenCreateTypeServiceWindow()
        {
            if(createTypeServicesWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<CreateTypeServicesWindow>();
            window.Closed += (_, _) => createTypeServicesWindow = null;
            createTypeServicesWindow = window;
            window.Show();
        }

        private UpdateTypeServiceWindow updateTypeServiceWindow;
        public void OpenUpdateTypeServiceWindow()
        {
            if (updateTypeServiceWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<UpdateTypeServiceWindow>();
            window.Closed += (_, _) => updateTypeServiceWindow = null;
            updateTypeServiceWindow = window;
            window.Show();
        }

        private CreateRegistrationServicesWindow createRegistrationServicesWindow;
        public void OpenCreateRegistrationWindow()
        {
            if (createRegistrationServicesWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<CreateRegistrationServicesWindow>();
            window.Closed += (_, _) => createRegistrationServicesWindow = null;
            createRegistrationServicesWindow = window;
            window.Show();
        }

        private UpdateRegistrationServiceWindow updateRegistrationServicesWindow;
        public void OpenUpdateRegistrationWindow()
        {
            if (updateRegistrationServicesWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _services.GetRequiredService<UpdateRegistrationServiceWindow>();
            window.Closed += (_, _) => updateRegistrationServicesWindow = null;
            updateRegistrationServicesWindow = window;
            window.Show();
        }
    }
}
