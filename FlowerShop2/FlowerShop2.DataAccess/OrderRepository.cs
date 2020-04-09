using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlowerShop2.Domain;
using FlowerShop2.Domain.Model;

namespace FlowerShop2.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        readonly FlowersContext context;
        public OrderRepository(FlowersContext context)
        {
            this.context = context;
        }
        public OrderRepository()
        {
            this.context = new FlowersContext();
        }
        public void RemoveOrderItem(OrderLine item)
        {
            context.OrderLine.Remove(item);
            context.SaveChanges();
        }
        public IEnumerable<Store> GetStores()
        {
            return context.Store;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await context.Order.Include(o => o.Customer).Include(o => o.Store).ToListAsync();
        }

        public void Remove(int id)
        {
           try
           {
               var toRemove = context.Order.Include(x => x.OrderLine).FirstOrDefault(x => x.SaleId == id);
               context.OrderLine.RemoveRange(toRemove.OrderLine);
               context.Remove(toRemove);
               context.SaveChanges();
           }
           catch(DbUpdateException)
           {
               return;
           }
        }

        public Order FindByID(int id)
        {
            var find = context.Order.Include(x => x.CustomerId).Include(x => x.StoreId)
                                    .Include("OrderLine.P").Include("OrderLine.P.P")
                                    .FirstOrDefault(y => y.SaleId == id);
                context.Entry(find).Reload();
                return find;
        }

        public int Create(Order order)
        {
            context.Order.Add(order);
            context.SaveChanges();
            context.Entry(order).Reload();
            return order.CustomerId;
        }

        public void Edit(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void AddOrderLine(OrderLine item)
        {
            context.OrderLine.Add(item);
            context.SaveChanges();
        }
    }
}