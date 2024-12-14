using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string OwnerName { get; set; }
        public string CardNo { get; set; }
        public string ExpiryDate { get; set; }
        public int? CvvNo { get; set; }
        public string BillingAddress { get; set; }
        public string PaymentMethod { get; set; }
    }
}