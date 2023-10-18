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
    internal class CRUDPositions
    {
        public ObservableCollection<Position> ReadPositions()
        {
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                var positions = new ObservableCollection<Position>(db.Positions.ToList());
                return positions;
            }
        }

        public bool CreatePosition(string nameposition)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                try
                {
                    Position AddPosition = new Position
                    {
                        Position1 = nameposition,
                    };
                    db.Positions.Add(AddPosition);
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception ) 
                {
                    MessageBox.Show("Ошибка при создание записи");
                    result = false;
                }
            }
            return result;
        }


        public bool UpdatePosition(Position newPosition)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                Position OldPosition = db.Positions.FirstOrDefault(p => p.Idposition == newPosition.Idposition);
                {
                    OldPosition.Position1 = newPosition.Position1;
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public bool DeletePosition(Position position)
        {
            bool result = false;
            using (StomatologicClinicContext db = new StomatologicClinicContext())
            {
                db.Positions.Remove(position);
                db.SaveChanges();
                result = true;
            }
            return result;
        }

    }
}
