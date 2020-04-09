using System.Collections.Generic;
using System.Threading.Tasks;
using FlowerShop2.Domain.Model;

namespace FlowerShop2.Domain
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrders();

        public int Remove(int id);
        public Order FindByID(int id);

        public int Create(Order order);
        public void Edit(Order order);
        void AddOrderLine(OrderLine item);


    }
}