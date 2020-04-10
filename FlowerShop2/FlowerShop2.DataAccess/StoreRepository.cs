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

        public void UpdateInventory(int InventoryID, int quantity)
        {

            var update = context.Inventory.Find(InventoryID);
            update.InventoryCount -= quantity;
            context.SaveChanges();

        }

        public int GetQuantity(int InventoryID)
        {
            return context.Inventory.Find(InventoryID).InventoryCount;
        }

        public List<Inventory> GetInventory(int id)
        {
            var listInventoryModel = context.Inventory
                        .Include("Product").Where(i => i.StoreId == id).ToList();
            return listInventoryModel;

        }

        public IEnumerable<Store> GetLocations()
        {
            return context.Store.Include("P.P");
        }
        public void Add(Store S)
        {
            context.Store.Add(S);
        }
        public void Edit(Store S)
        {
            context.Entry(S).State = EntityState.Modified;
        }
    }
}