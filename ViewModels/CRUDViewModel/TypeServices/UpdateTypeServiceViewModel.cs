using CourseWork.Infrastructure.Commands;
using CourseWork.Models.Data;
using CourseWork.Models.Tables;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels.CRUDViewModel.TypeService
{
    internal class UpdateTypeServiceViewModel : TitleViewModel
    {
        public Models.Tables.TypeService TypeServiceSelectetTabItem { get; set; }
        CRUDTypeService _CRUDTypeService = new CRUDTypeService();
        CRUDCategories _CRUDCategories = new CRUDCategories();

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set => Set(ref _categories, value);
        }

        private LambdaCommand? _updateTypeService;

        public ICommand UpdateTypeService => _updateTypeService ??= new(_updateTypeServiceExecuted);

        public void _updateTypeServiceExecuted()
        {
            _CRUDTypeService.UpdateTypeService(TypeServiceSelectetTabItem);
        }


        public UpdateTypeServiceViewModel()
        {
            Title = "Изменение категории";
            TypeServiceSelectetTabItem = MainWindowViewModel.SelectedTypeService;
            Categories = _CRUDCategories.ReadCatigories();
        }
    }
}
