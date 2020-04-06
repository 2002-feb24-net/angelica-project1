using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MvcFlowerShop.Models
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
