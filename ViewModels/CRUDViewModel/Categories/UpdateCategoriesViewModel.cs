using CourseWork.Infrastructure.Commands;
using CourseWork.Models.Data;
using CourseWork.Models.Table;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels.CRUDViewModel.Categories
{
    internal class UpdateCategoriesViewModel : TitleViewModel
    {
        public Category CategorySelectetTabItem { get; set; }
        CRUDCategories _CRUDCategories = new CRUDCategories();


        private LambdaCommand? _updateCategory;

        public ICommand UpdateCategory => _updateCategory ??= new(_updateCategoryExecuted);

        public void _updateCategoryExecuted()
        {
            _CRUDCategories.UpdateCategory(CategorySelectetTabItem);
        }


        public UpdateCategoriesViewModel() 
        {
            Title = "Изменение категории";
            CategorySelectetTabItem = MainWindowViewModel.SelectedCategories;
        }
    }
}
