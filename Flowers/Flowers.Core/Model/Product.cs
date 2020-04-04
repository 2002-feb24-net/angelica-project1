using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowers.Core.Model
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public List<Inventory> Inventory { get; set; } = new List<Inventory>();

    }
}