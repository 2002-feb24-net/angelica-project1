using System;
using System.Collections.Generic;

namespace FlowerShop2.Domain.Model
{
    public partial class OrderLine
    {
        public int OrderLineId { get; set; }
        public int Quantity { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Sale { get; set; }
    }
}
