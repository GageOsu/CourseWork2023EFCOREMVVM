using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Services
{
    internal interface IWorkUser
    {
        void OpenAuthorizationWindow();
        void OpenMainWindow();

        void OpenCreateWindow();

        void OpenUpdateEmployeeWindow();

        void OpenCreateCategoryWindow();

        void OpenUpdateCategoryWindow();

        void OpenCreatePatientWindow();

        void OpenUpdatePatientWindow();

        void OpenCreatePositionWindow();

        void OpenUpdatePositionWindow();

        void OpenCreateTypeServiceWindow();

        void OpenUpdateTypeServiceWindow();

        void OpenCreateRegistrationWindow();

        void OpenUpdateRegistrationWindow();

    }
}
