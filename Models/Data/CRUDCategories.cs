using CourseWork.Models.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork.Models.Data
{
    internal class CRUDCategories
    {
        public ObservableCollection<Category> ReadCatigories()
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                var catgories = new ObservableCollection<Category>(db.Categories.Local);
                return catgories;
            }
        }

        public bool CreateCategory(string category)
        {
            bool result = false;
            try
            {
                using (StomatologicClinicContext db = new StomatologicClinicContext())
                {
                    Category newCategory = new Category
                    {
                        Category1 = category
                    };
                    db.Categories.Add(newCategory);
                    db.SaveChanges();
                    ReadCatigories();
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


        public static bool UpdateCategory(Category newCategory)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                Category OldCategory = db.Categories.FirstOrDefault(p => p.Idcategory == newCategory.Idcategory);
                {
                    OldCategory.Category1 = newCategory.Category1;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public static bool DeleteCategory(Category category)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
