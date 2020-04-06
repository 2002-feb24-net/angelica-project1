using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Flowers.WebUI.Models
{
    public class CustomerViewModel
    {
        public int customerID{ get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName {get; set;}

        [Display(Name="Last Name")]
        public string LastName {get; set;}

        [Display(Name="Username")]
        public string Username{get; set;}

    }
}