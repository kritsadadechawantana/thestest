using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace posapi.Models.ViewModels
{
    public class CartVM
    {
        public string Id { get; set; }
        public List<CartItemVM> CartItems { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
    }

    public class CartItemVM
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
        public double TotalPrice { get; set; }
    }
}
