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
            context = new FlowersContext();
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            throw new System.NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Order FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Create(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void AddOrderLine(OrderLine item)
        {
            throw new System.NotImplementedException();
        }
    }
}