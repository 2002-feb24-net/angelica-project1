using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MvcFlowerShop.Models
{
    public partial class Order
    {
        public int SaleId { get; set; }

        [Required]
        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime SaleDate { get; set; }

        [Required]
        [DisplayName("Store Id")]
        public int StoreId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal OrderTotal { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }

    }
}
