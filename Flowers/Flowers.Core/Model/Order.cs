using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowers.Core.Model
{
    public class Order
    {
        private int _SaleID {get; set;}
        private int? _CustomerID;
        private DateTime _SaleDate;
        private decimal? _OrderTotal; //check if decimal is right

        public int? CustomerID
        {
            get => _CustomerID;

        }

        //  public double? OrderTotal
        // {
        //     // get
        //     // {
        //     // if (OrderTotal.Count > 0)
        //     //     {
        //     //         // use LINQ with a lambda expression to calculate the order total.
        //     //         // this needs to be fixed i know its not right
        //     //         return OrderTotal.Sum(o => o.OrderTotal);
        //     //     }
        //     //     return null;
        //     // }

        // }




    }
}