using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IntroSQL
{
    class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string newProductName, int newPrice, int newOnSale, int newStockLevel)
        {
            
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var prod= _connection.Query<Product>("SELECT * FROM Products;").ToList();
            return prod;
        }
        public void InsertProduct(string newProductName, int newPrice, int newOnSale, int newStockLevel )
        {
            _connection.Execute("INSERT INTO PRODUCTS (productName, Price, OnSale, StockLevel) VALUES (@productName, @price, @onSale, @stockLevel);",
              new { productName = newProductName, price=newPrice, onSale=newOnSale, stockLevel=newStockLevel });
        }


    }
}
