using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IntroSQL
{
    public class DapperDepartmentRepository:IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        
        public IEnumerable<Department> GetAllDepartments()
        {
            var depo=_connection.Query<Department>("SELECT * FROM Departments;").ToList();
            return depo;
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
              new { departmentName = newDepartmentName });
        }
    }


}

