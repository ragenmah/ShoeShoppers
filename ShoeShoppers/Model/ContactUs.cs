using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Model
{
    public class ContactUs
    {
        public int ContactUsId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsReplied { get; set; }
        public DateTime? RepliedAt { get; set; }
        public string RepliedBy { get; set; }
    }
}