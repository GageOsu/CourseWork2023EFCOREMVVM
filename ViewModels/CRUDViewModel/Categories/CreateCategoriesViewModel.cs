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

namespace CourseWork.ViewModels.CRUDViewModel.Categories
{
    internal class CreateCategoriesViewModel : TitleViewModel
    {
        private string _category;
        public string Category
        {
            get => _category;
            set => Set(ref _category, value);
        }

        private readonly IWorkUser _workUser;
        private CRUDCategories _CRUDCategories = new CRUDCategories();
        private MainWindowViewModel _mainWindowViewModel;



        private LambdaCommand? _createCategory;

        public ICommand CreateCategory => _createCategory ??= new(_createCategoryExecuted);

        public void _createCategoryExecuted()
        {
            _CRUDCategories.CreateCategory(Category);
        }


        public CreateCategoriesViewModel() 
        {
            Title = "Создание Категории";
        }
        public CreateCategoriesViewModel(IWorkUser workUser) : this() 
        { 
            _workUser = workUser;
        }
    }
}
