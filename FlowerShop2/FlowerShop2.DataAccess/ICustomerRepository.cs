using System.Collections.Generic;
using System.Threading.Tasks;
using FlowerShop2.DataAccess.Model;

namespace FlowerShop2.DataAccess
{
    public interface ICustomerRepository
    {
        // add a customer
        public int Create(Customer customer);

        // delete customer
        public void Delete(string Username);

        // search for a customer
        public Customer FindByUsername(string Username);

        // edit a customer
        public void Edit(Customer customer);

        public Task<IEnumerable<Customer>> GetCustomers();




    }
}