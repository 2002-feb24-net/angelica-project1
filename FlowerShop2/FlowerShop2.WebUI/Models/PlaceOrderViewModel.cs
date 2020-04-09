using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FlowerShop2.Domain.Model;


namespace FlowerShop2.WebUI.Models
{
    public class PlaceOrderViewModel
    {
        public List<Inventory> Inventory {get; set;}
        public OrderLine Item {get; set;}

    }
}