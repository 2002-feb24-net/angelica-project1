using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFlowerShop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }

        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
