using System.Collections.Generic;
using System.Threading.Tasks;
using FlowerShop2.Domain.Model;

namespace FlowerShop2.Domain
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetCustomers();
        public int Create(Customer customer);

        public void Remove(int id);
        public void Update(Customer customer);

        public Customer FindByID(string Username);

    }
}