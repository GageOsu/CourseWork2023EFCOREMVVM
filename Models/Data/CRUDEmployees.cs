using CourseWork.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork.Models.Data
{
    internal class CRUDEmployees
    {
        public ObservableCollection<Employee> ReadEmployes()
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                var employees = new ObservableCollection<Employee>(db.Employees.Include(u => u.IdpositionNavigation));
                return employees;
            }
        }

        public bool CreateEmployes(string surname, string name, string middleName, Position positions)
        {
            bool result = false;
            try
            {
                using (StomatologicClinicContext db = new StomatologicClinicContext())
                {
                    Employee newEmployee = new Employee
                    {
                        SurnameEmployee = surname,
                        NameEmployee = name,
                        MiddleNameEmployee = middleName,
                        Idposition = positions.Idposition,
                    };
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                    ReadEmployes();
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

        public  bool DeleteEmployee(Employee employee)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public  bool UpdateEmployee(Employee NewEmployee)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                Employee OldEmployee = db.Employees.FirstOrDefault(p => p.Idemployee == NewEmployee.Idemployee);
                {
                    OldEmployee.SurnameEmployee = NewEmployee.SurnameEmployee;
                    OldEmployee.NameEmployee = NewEmployee.NameEmployee;
                    OldEmployee.MiddleNameEmployee = NewEmployee.MiddleNameEmployee;
                    OldEmployee.Idposition = NewEmployee.Idposition;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
    }
}
