using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using posapi.Models;
using posapi.Models.ViewModels;

namespace posapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class POSController : ControllerBase
    {
        static List<Product> products = new List<Product>
            {
               new Product{ Id = "1", Name = "Iphone XS Max", Price = 43500},
               new Product{ Id = "2", Name = "Ipad pro", Price = 35000},
               new Product{ Id = "3", Name = "Samsung Galaxy S10", Price = 38000}
            };

        static List<Cart> carts = new List<Cart>
            {
                new Cart{ CartItems = new List<CartItem>{}}
            };

        private readonly ProductService productService;
        private readonly CartService cartService;

        public POSController()
        {
            this.productService = new ProductService(products);
            this.cartService = new CartService(products, carts);
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            return productService.GetAllProducts();
        }

        [HttpPost]
        public void AddProduct(Product model)
        {
            productService.AddProduct(model);
        }

        [HttpPost("{productId}/{quantity}")]
        public void AddItem(string productId, int quantity)
        {
            cartService.AddItem(productId, quantity);
        }

        [HttpGet]
        public CartVM GetCart()
        {
            return cartService.GetCart();
        }
    }
}
