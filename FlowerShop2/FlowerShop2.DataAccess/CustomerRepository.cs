using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlowerShop2.Domain;
using FlowerShop2.Domain.Model;


namespace FlowerShop2.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly FlowersContext context;
        public CustomerRepository(FlowersContext context)
        {
            this.context = context;
        }
        public CustomerRepository()
        {
            context = new FlowersContext();
        }

        public int Create(Customer customer)
        {
            context.Customer.Add(customer);
            context.Entry(customer).Reload();
            context.SaveChanges();
            return customer.CustomerId;
        }

        public Customer FindByID(int id)
        {

            return context.Customer.Find(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await context.Customer.ToListAsync();
        }

        public void Remove(int id)
        {
            var _Remove = context.Customer.Find(id);
            context.Customer.Remove(_Remove);
            context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var old = FindByID(customer.CustomerId);
            context.Entry(old).State = EntityState.Detached;
            context.Set<Customer>().Attach(customer);
            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}