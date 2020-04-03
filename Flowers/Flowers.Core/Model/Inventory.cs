using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowers.Core.Model
{
    public class Inventory
    {
        private int _InventoryID{get; set;}
        private int? _StoreID;
        private int? _ProductID;
        private int? _InventoryCount;

         public int? StoreID
        {
            get => _StoreID;

        }

        public int? ProductID
        {
            get => _ProductID;

        }

        public int? InventoryCount
        {
            get => _InventoryCount;

        }


    }
}