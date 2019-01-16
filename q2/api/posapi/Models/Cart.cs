using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace posapi.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public List<CartItem> CartItems { get; set; }
    }

    public class CartItem
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
