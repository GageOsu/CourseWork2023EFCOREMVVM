using CourseWork.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
