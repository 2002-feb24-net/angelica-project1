using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MvcFlowerShop.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MvcFlowerShop.ViewModels
{
    public class OrderProductViewModel
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        [Display(Name ="Choose a customer")]
        public int CustomerChoice { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }

        public List<Store> Stores { get; set; } = new List<Store>();
        [Display(Name ="Choose a store location")]
        public int LocationChoice { get; set; }
        public IEnumerable<SelectListItem> LocationList { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        [Display(Name ="Choose a flower")]
        public int ProductChoice { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }


    }
}