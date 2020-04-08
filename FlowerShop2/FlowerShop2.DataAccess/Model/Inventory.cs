using System;
using System.Collections.Generic;

namespace FlowerShop2.DataAccess.Model
{
    public partial class Inventory
    {
        public Inventory()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int InventoryId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int InventoryCount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
