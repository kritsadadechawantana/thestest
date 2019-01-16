using posapi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace posapi.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public void AddProduct_Test()
        {
            var productDataStore = new List<Product>
            {
               new Product{ Id = "1", Name = "Iphone XS Max", Price = 43500},
               new Product{ Id = "2", Name = "Ipad pro", Price = 35000}
            };

            var productService = new ProductService(productDataStore);
            productService.AddProduct(new Product
            {
                Name = "Samsung Galaxy S10",
                Price = 38000
            });

            var expected = new List<Product>
            {
               new Product{ Id = "1", Name = "Iphone XS Max", Price = 43500},
               new Product{ Id = "2", Name = "Ipad pro", Price = 35000},
               new Product{ Id = "3", Name = "Samsung Galaxy S10", Price = 38000}
            };

            productDataStore.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllProducts_Test()
        {
            var productDataStore = new List<Product>
            {
               new Product{ Id = "1", Name = "Iphone XS Max", Price = 43500},
               new Product{ Id = "2", Name = "Ipad pro", Price = 35000}
            };

            var productService = new ProductService(productDataStore);
            var result = productService.GetAllProducts();

            result.Should().BeEquivalentTo(productDataStore);
        }
    }
}
