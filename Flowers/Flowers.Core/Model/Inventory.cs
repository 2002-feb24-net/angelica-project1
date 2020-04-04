using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowers.Core.Model
{
    public class Inventory
    {
        private int _StoreId;
        private int _ProductId;
        private int _InventoryCount;
        public int InventoryId { get; set; }

        public int StoreId { get; set; }
        public int ProductId { get; set; }

        public int InventoryCount
        {
            get => _InventoryCount;
               set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value may not be a negative number.", nameof(value));
                }
                _InventoryCount = value;
            }

        }

    }
}