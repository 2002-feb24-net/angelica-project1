using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowers.Core.Model
{
    public class Product
    {
        private int _ProductID {get; set;}
        private string _ProductName;
        private decimal _ProductPrice; //check if decimal

         public string ProductName
        {
            get => _ProductName;

        }

         public decimal ProductPrice
        {
            get => _ProductPrice;

        }

    }
}