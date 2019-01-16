using posapi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using posapi.Models.ViewModels;

namespace posapi.Test
{
    public class CartServiceTest
    {
        [Fact]
        public void AddItem_Test()
        {
            var productDataStore = new List<Product>
            {
               new Product{ Id = "1", Name = "Iphone XS Max", Price = 43500},
               new Product{ Id = "2", Name = "Ipad pro", Price = 35000},
               new Product{ Id = "3", Name = "Samsung Galaxy S10", Price = 38000}
            };
            var cartDataStore = new List<Cart>
            {
                new Cart{ CartItems = new List<CartItem>()}
            };

            var cartService = new CartService(productDataStore, cartDataStore);
            cartService.AddItem("3", 1);

            var expected = new List<Cart>
            {
                new Cart{ CartItems = new List<CartItem>{
                    new CartItem{ ProductId = "3", Quantity = 1}
                }}
            };

            cartDataStore.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetCart_Without_Discount_Test()
        {
            var productDataStore = new List<Product>
            {
               new Product{ Id = "1", Name = "Iphone XS Max", Price = 43500},
               new Product{ Id = "2", Name = "Ipad pro", Price = 35000},
               new Product{ Id = "3", Name = "Samsung Galaxy S10", Price = 38000}
            };
            var cartDataStore = new List<Cart>
            {
                new Cart{ CartItems = new List<CartItem>{
                    new CartItem{ ProductId = "3", Quantity = 1},
                    new CartItem{ ProductId = "2", Quantity = 2}
                }}
            };

            var cartService = new CartService(productDataStore, cartDataStore);
            var cart = cartService.GetCart();

            var expected = new CartVM
            {
                TotalPrice = 108000,
                DiscountPrice = 108000,
                CartItems = new List<CartItemVM>{
                    new CartItemVM{ ProductId = "3", Name = "Samsung Galaxy S10", Quantity = 1, PricePerUnit = 38000, TotalPrice = 38000},
                    new CartItemVM{ ProductId = "2", Name = "Ipad pro", Quantity = 2, PricePerUnit = 35000, TotalPrice = 70000},
                }
            };

            cart.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetCart_With_Discount_Test()
        {
            var productDataStore = new List<Product>
            {
               new Product{ Id = "1", Name = "Iphone XS Max", Price = 43500},
               new Product{ Id = "2", Name = "Ipad pro", Price = 35000},
               new Product{ Id = "3", Name = "Samsung Galaxy S10", Price = 38000}
            };
            var cartDataStore = new List<Cart>
            {
                new Cart{ CartItems = new List<CartItem>{
                    new CartItem{ ProductId = "3", Quantity = 4}
                }}
            };

            var cartService = new CartService(productDataStore, cartDataStore);
            var cart = cartService.GetCart();

            var expected = new CartVM
            {
                TotalPrice = 152000,
                DiscountPrice = 114000,
                CartItems = new List<CartItemVM>{
                    new CartItemVM{ ProductId = "3", Name = "Samsung Galaxy S10", Quantity = 4, PricePerUnit = 38000, TotalPrice = 152000},
                }
            };

            cart.Should().BeEquivalentTo(expected);
        }
    }
}
