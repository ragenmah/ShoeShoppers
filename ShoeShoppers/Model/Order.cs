using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCancelled { get; set; }
    }
}