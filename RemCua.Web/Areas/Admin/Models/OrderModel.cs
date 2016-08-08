using RemCua.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemCua.Web.Areas.Admin.Models
{
    public class OrderModel
    {
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Product Product { get; set; }
    }
}