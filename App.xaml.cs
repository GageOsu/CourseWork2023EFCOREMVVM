using CourseWork.Services;
using CourseWork.ViewModels;
using CourseWork.ViewModels.CRUDViewModel.Categories;
using CourseWork.ViewModels.CRUDViewModel.Employees;
using CourseWork.ViewModels.CRUDViewModel.Patients;
using CourseWork.Views.CRUDView.Category;
using CourseWork.Views.CRUDView.Employee;
using CourseWork.Views.CRUDView.Patient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider? _services;

        public static IServiceProvider Services => _services??= InitializeServices().BuildServiceProvider();

        private static IServiceCollection InitializeServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<CreateEmployeeViewModel>();
            services.AddTransient<UpdateEmployeeViewModel>();
            services.AddTransient<CreateCategoriesViewModel>();
            services.AddTransient<UpdateCategoriesViewModel>();
            services.AddTransient<CreatePatientViewModel>();
            services.AddTransient<UpdatePatientViewModel>();

            services.AddSingleton<IWorkUser, WorkUser>();

            services.AddTransient(
                s => 
                {
                    var model = s.GetRequiredService<MainWindowViewModel>();
                    var window = new MainWindow { DataContext = model };
                    return window;
                });

            services.AddTransient(
                s =>
                {
                    var model = s.GetRequiredService<CreateEmployeeViewModel>();
                    var window = new CreateEmployeeWindows { DataContext = model };
                    return window;
                });
            services.AddTransient(
                s =>
                {
                    var model = s.GetRequiredService<UpdateEmployeeViewModel>();
                    var window = new UpdateEmployeeWindow { DataContext = model };
                    return window;
                });
            services.AddTransient(
                s =>
                {
                    var model = s.GetRequiredService<CreateCategoriesViewModel>();
                    var window = new CreateCategoryWindow { DataContext = model };
                    return window;
                });
            services.AddTransient(
                s =>
                {
                    var model = s.GetRequiredService<UpdateCategoriesViewModel>();
                    var window = new UpdateCategoryWindow { DataContext = model };
                    return window;
                });
            services.AddTransient(
                s =>
                {
                    var model = s.GetRequiredService<CreatePatientViewModel>();
                    var window = new CreatePatientWindow { DataContext = model };
                    return window;
                });
            services.AddTransient(
                s =>
                {
                    var model = s.GetRequiredService<UpdatePatientViewModel>();
                    var window = new UpdatePatientWindow { DataContext = model };
                    return window;
                });


            return services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Services.GetRequiredService<IWorkUser>().OpenMainWindow();
        }
    }
}
