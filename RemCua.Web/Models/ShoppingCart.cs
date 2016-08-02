using RemCua.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemCua.Web.Models
{
    [Serializable]
    public class ShoppingCart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public List<Product> Items = new List<Product>();
    }
}