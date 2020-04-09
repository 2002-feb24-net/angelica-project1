using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FlowerShop2.Domain.Model;

namespace FlowerShop2.WebUI.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public string Username {get; set;}
        public int CustomerId {get; set;}

        public int StoreId {get; set;}

        public decimal OrderTotal {get; set;}
        public DateTime SaleDate {get; set;}
        public virtual Store Store {get; set;}
        public virtual Customer Customer {get; set;}
        public virtual ICollection<OrderLine> OrderLine {get; set;}


    }
}