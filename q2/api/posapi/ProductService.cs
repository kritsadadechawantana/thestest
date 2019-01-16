using posapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace posapi
{
    public class ProductService
    {
        private readonly List<Product> productDataStore;

        public ProductService(List<Product> productDataStore)
        {
            this.productDataStore = productDataStore;
        }

        public void AddProduct(Product product)
        {
            productDataStore.Add(new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = product.Name,
                Price = product.Price
            });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productDataStore;
        }
    }
}
