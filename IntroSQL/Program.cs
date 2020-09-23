using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.Common;

namespace IntroSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

           Console.WriteLine("Hello user. Here are current departments in the database:");

           var depos= repo.GetAllDepartments();
           foreach(var depo in depos)
            {
                Console.WriteLine($"ID-{depo.DepartmentID} Name-{depo.Name}");
            }

            Console.WriteLine("Do you want to add another department?");
            String userResponce = Console.ReadLine();

            if (userResponce.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of the department you want to add: ");
                var newDep = Console.ReadLine();
                repo.InsertDepartment(newDep);
                repo.GetAllDepartments();
            }

        }
       /* public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }
        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }
        public void InsertProducts(string newProductName)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name,) VALUES (@productsName);",
            new { productName = newProductName });
        }
*/
    }
}
