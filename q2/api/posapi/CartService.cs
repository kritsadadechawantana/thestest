using posapi.Models;
using posapi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace posapi
{
    public class CartService
    {
        private readonly List<Product> productDataStore;
        private readonly List<Cart> cartDataStore;

        public CartService(List<Product> productDataStore, List<Cart> cartDataStore)
        {
            this.productDataStore = productDataStore;
            this.cartDataStore = cartDataStore;
        }

        public void AddItem(string productId, int quantity)
        {
            var selectedCart = cartDataStore.FirstOrDefault();
            var selectedProduct = productDataStore.FirstOrDefault(it => it.Id == productId);

            var hasExist = selectedCart.CartItems.Any(it => it.ProductId == productId);

            if(hasExist)
            {
                var selectedCartItem = selectedCart.CartItems.FirstOrDefault(it => it.ProductId == productId);
                selectedCartItem.Quantity += quantity;
            }
            else
            {
                selectedCart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
        }

        public CartVM GetCart()
        {
            var selectedCart = cartDataStore.FirstOrDefault();
            var totalPrice = selectedCart.CartItems.Sum(it => {
                var product = productDataStore.FirstOrDefault(p => p.Id == it.ProductId);
                return product.Price * it.Quantity;
            });

            var discountedPrice = selectedCart.CartItems.Select(it =>
            {
                var product = productDataStore.FirstOrDefault(p => p.Id == it.ProductId);
                return it.Quantity > 3 ? product.Price * (it.Quantity - (it.Quantity % 3)): product.Price * it.Quantity;
            }).Sum();

            var cartItems = selectedCart.CartItems.Select(it =>
            {
                var product = productDataStore.FirstOrDefault(p => p.Id == it.ProductId);
                return new CartItemVM
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Quantity = it.Quantity,
                    PricePerUnit = product.Price,
                    TotalPrice = it.Quantity * product.Price
                };
            }).ToList();

            return new CartVM {
                Id = selectedCart.Id,
                CartItems = cartItems,
                TotalPrice = totalPrice,
                DiscountPrice = discountedPrice
            };
        }
    }
}
