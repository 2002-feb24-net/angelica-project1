using System;
using System.Collections.Generic;

namespace FlowerShop2.DataAccess.Model
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            OrderLine = new HashSet<OrderLine>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
