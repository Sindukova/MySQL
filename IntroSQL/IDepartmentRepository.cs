using System;
using System.Collections.Generic;
using System.Text;

namespace IntroSQL
{
    interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments(); //Stubbedout method

        //void CreateDepartment(string Name, int DepartmentID);

    }
}
