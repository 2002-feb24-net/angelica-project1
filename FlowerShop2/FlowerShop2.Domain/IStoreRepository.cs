using System.Collections.Generic;
using System.Threading.Tasks;
using FlowerShop2.Domain.Model;

namespace FlowerShop2.Domain
{
    public interface IStoreRepository
    {
        void UpdateInventory(int InventoryId, int quantity);

        int GetQuantity(int InventoryId);

        List<Inventory> GetInventory(int InventoryId);

    }
}