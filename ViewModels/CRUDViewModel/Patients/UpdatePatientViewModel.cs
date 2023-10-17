using CourseWork.Infrastructure.Commands;
using CourseWork.Models.Data;
using CourseWork.Models.Tables;
using CourseWork.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModels.CRUDViewModel.Patients
{
    internal class UpdatePatientViewModel : TitleViewModel
    {
        public Patient PatientSelectetTabItem { get; set; }
        CRUDPatients _CRUDPatients = new CRUDPatients();

        private List<String> typeLocality = new List<string> { "Город", "Городской поселок", "Деревня", "Село", "Станция", "Аул", "Хутор", "Кишлак" };
        private List<String> typeSubject = new List<string> { "Республика", "Край", "Область", "Город федерального значения", "Автономная область", "Автономный округ" };
        private List<string> sex = new List<string>() { "МУЖ", "ЖЕН" };

        public List<String> TypeLocality
        {
            get => typeLocality;
            set => Set(ref typeLocality, value);
        }
        public List<String> TypeSubject
        {
            get => typeSubject;
            set => Set(ref typeSubject, value);
        }
        public List<String> Sex
        {
            get => sex;
            set => Set(ref sex, value);
        }

        private LambdaCommand? _updatePatient;

        public ICommand UpdatePatient => _updatePatient ??= new(_updateCategoryExecuted);

        public void _updateCategoryExecuted()
        {
            _CRUDPatients.UpdatePatient(PatientSelectetTabItem);
        }


        public UpdatePatientViewModel()
        {
            Title = "Изменение категории";
            PatientSelectetTabItem = MainWindowViewModel.SelectedPatients;
        }
    }
}