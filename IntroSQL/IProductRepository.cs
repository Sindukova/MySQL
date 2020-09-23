using System;
using System.Collections.Generic;
using System.Text;

namespace IntroSQL
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); 
        //
        void CreateProduct(string newProductName, int newPrice, int newOnSale, int newStockLevel);

    }
}
