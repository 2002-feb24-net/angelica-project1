using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowers.Core.Model
{
    public class Order
    {
        private int _CustomerId;
        private decimal _OrderTotal;
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public int StoreId { get; set; }

        public int CustomerId
        {
            get => _CustomerId;
             set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _CustomerId = value;
            }

        }

        public decimal OrderTotal
        { get => _OrderTotal;
             set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _OrderTotal = value;
            }
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