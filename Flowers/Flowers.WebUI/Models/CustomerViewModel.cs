using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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