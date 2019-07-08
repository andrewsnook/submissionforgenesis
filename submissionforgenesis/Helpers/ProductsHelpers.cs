using System;
using System.Collections.Generic;
using submissionforgenesis.Models;

namespace submissionforgenesis.Helpers
{
    public static class ProductsHelpers
    {
        public static List<Product> GetListOfProducts()
        {
            var product1 = new Product
            {
                Id = 1,
                Name = "Product 1",
                Price = 40M
            };

            var product2 = new Product
            {
                Id = 2,
                Name = "Product 2",
                Price = 10M
            };

            var product3 = new Product
            {
                Id = 3,
                Name = "Product 3",
                Price = 50M
            };

            var listOfProducts = new List<Product>
                {
                    product1,
                    product2,
                    product3
                };

            return listOfProducts;
        }
    }
}
