using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFlowerShop.Models
{
    public class OrderProductViewModel
    {
        public Product product {get; set;}

        public Order order{get; set;}

    }
}