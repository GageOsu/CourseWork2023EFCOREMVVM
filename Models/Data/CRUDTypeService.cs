using CourseWork.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork.Models.Data
{
    internal class CRUDTypeService
    {
        public ObservableCollection<TypeService> ReadTypeServices()
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                var typeServices = new ObservableCollection<TypeService>(db.TypeServices.Include(u => u.IdcategoryNavigation.Category1));
                return typeServices;
            }
        }

        public bool CreateTypeService(string nameService, decimal priceService, Category category)
        {
            bool result = false;
            try
            {
                using (StomatologicClinicContext db = new StomatologicClinicContext())
                {
                    TypeService newTypeService = new TypeService
                    {
                        Idcategory = category.Idcategory,
                        NameService = nameService,
                        PriceService = priceService,
                    };
                    db.TypeServices.Add(newTypeService);
                    db.SaveChanges();
                    ReadTypeServices();
                    result = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при создание записи");
                result = false;
            }
            return result;
        }

        public static bool UpdateTypeService(TypeService newTypeSevice)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                TypeService OldTypeService = db.TypeServices.FirstOrDefault(p => p.Idservice == newTypeSevice.Idservice);
                {
                    OldTypeService.Idcategory = newTypeSevice.Idcategory;
                    OldTypeService.NameService = newTypeSevice.NameService;
                    OldTypeService.PriceService = newTypeSevice.PriceService;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public static bool DeleteTypeService(TypeService typeService)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                db.TypeServices.Remove(typeService);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
