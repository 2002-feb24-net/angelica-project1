using System.Collections.Generic;
using System.Threading.Tasks;
using FlowerShop2.Domain.Model;

namespace FlowerShop2.Domain
{
    public interface IStoreRepository
    {
        void UpdateInventory(int id, int quantitty);

        int GetQuantity(int id);

        List<Inventory> GetInventory(int id);

    }
}