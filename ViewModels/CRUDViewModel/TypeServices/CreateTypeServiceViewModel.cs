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
    internal class CreateTypeServiceViewModel : TitleViewModel
    {
        private CRUDTypeService _CRUDTypeService = new CRUDTypeService();
        private CRUDCategories _CRUDCategories = new CRUDCategories();
        private ObservableCollection<Category> _categories;
        private Category _category;
        private string _nameService;
        private decimal _priceService;
        public string NameService
        {
            get => _nameService;
            set => Set(ref _nameService, value);
        }
        public decimal PriceService
        {
            get => _priceService;
            set => Set(ref _priceService, value);
        }
        public ObservableCollection<Category> Categories
        {
            get => _categories; 
            set => Set(ref _categories, value);
        }
        public Category Category
        {
            get => _category;
            set => Set(ref _category, value);
        }

        private LambdaCommand? _createTypeService;

        public ICommand CreateTypeService => _createTypeService ??= new(_createTypeServiceExecuted);

        public void _createTypeServiceExecuted()
        {
            _CRUDTypeService.CreateTypeService(NameService,PriceService,Category);
        }

        public CreateTypeServiceViewModel()
        {
            Title = "Создание услуги";
            Categories = new ObservableCollection<Category>(_CRUDCategories.ReadCatigories());
        }

    }
}
