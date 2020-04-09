using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;

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

        public bool ValidateQuantity( int quantity)
        {
            Debug.WriteLine(this.Quantity>0);
            return this.Quantity >0 && (this.Quantity < quantity * .5 || (this.Quantity < 100 && this.Quantity < quantity));
        }
    }
}
