using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MvcFlowerShop.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        [DisplayName("Store Id")]
        public int StoreId { get; set; }

        [Required]
        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int InventoryCount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
