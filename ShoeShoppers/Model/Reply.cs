using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Model
{
    public class Reply
    {
        public int ReplyId { get; set; }       
        public string ResponseContent { get; set; } 
        public DateTime? RepliedAt { get; set; }      
        public string RepliedBy { get; set; }
    }
}