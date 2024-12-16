using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Model
{
    public class ProductReview
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsReplied { get; set; }

        public int? ReplyId { get; set; }
        public virtual User User { get; set; }
        public Reply Reply { get; set; }
    }
}