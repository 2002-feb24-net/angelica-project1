using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MvcFlowerShop.Models
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
            Order = new HashSet<Order>();
        }

        public int StoreId { get; set; }

        [Required]
        [DisplayName("Store Name")]
        public string StoreName { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("State")]
        public string State { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        public int PostalCode { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
