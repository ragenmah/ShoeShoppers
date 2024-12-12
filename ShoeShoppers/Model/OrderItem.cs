﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}