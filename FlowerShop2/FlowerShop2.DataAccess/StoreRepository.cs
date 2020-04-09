using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlowerShop2.Domain;
using FlowerShop2.Domain.Model;

namespace FlowerShop2.DataAccess
{
    public class StoreRepository : IStoreRepository
    {
        readonly FlowersContext context;
        public StoreRepository(FlowersContext context)
        {
            this.context = context;
        }
        public StoreRepository()
        {
            context = new FlowersContext();
        }

        public void UpdateInventory(int id, int quantitty)
        {
            throw new System.NotImplementedException();
        }

        public int GetQuantity(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Inventory> GetInventory(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}