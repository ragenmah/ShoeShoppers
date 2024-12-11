using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercentage { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}