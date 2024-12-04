﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }
}