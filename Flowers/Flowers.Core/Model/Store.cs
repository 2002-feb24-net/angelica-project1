using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowers.Core.Model
{
    public class Store
    {
        // public Store(int _StoreID)
        // {
        //     this._StoreID = _StoreID;

        // }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Address  { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }

    public List<Inventory> Inventory { get; set; } = new List<Inventory>();
    public List<Order> Order { get; set; } = new List<Order>();

    }
}