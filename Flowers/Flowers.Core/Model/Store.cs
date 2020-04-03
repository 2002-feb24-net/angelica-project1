using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowers.Core.Model
{
    public class Store
    {
        public Store(int _StoreID)
        {
            this._StoreID = _StoreID;

        }
        private int _StoreID { get; set; }
        private string _StoreName;
        private string _Address;
        private string _City;
        private string _State;
        private int? _PostalCode;

        public string StoreName
        {
            get => _StoreName;
        }

        public string Address
        {
            get => _Address;
        }

        public string City
        {
            get => _City;
        }

        public string State
        {
            get => _State;
        }

        public int? PostalCode
        {
            get => _PostalCode;
        }

    public List<Inventory> Inventory { get; set; } = new List<Inventory>();
    public List<Order> Order { get; set; } = new List<Order>();

    }
}