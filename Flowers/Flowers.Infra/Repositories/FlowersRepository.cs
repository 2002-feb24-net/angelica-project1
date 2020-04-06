using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Flowers.Core.Interface;
using Flowers.Infra.Entities;


namespace Flowers.Infra.Repositories
{
    public class FlowersRepository : IFlowersRepository
    {
        private readonly FlowersContext _Context;
        public FlowersRepository(FlowersContext Context)
        {
            _Context = Context ?? throw new ArgumentException(nameof(Context));
        }
        public void AddCustomer(Core.Model.Customer customer)
        {
            Customer entity = Mapper.MapCustomer(customer);
            _Context.Add(entity);
        }

        public Core.Model.Customer GetCustomerById(string userName)
        {
            var customer = _Context.Customer
                .FirstOrDefault(c => c.Username == userName);
            if(customer != null)
            {
                return Mapper.MapCustomer(customer);
            }
            return null;
        }

        // public IEnumerable<Core.Model.Customer> GetCustomers(string search = null)
        // {
        //     throw new NotImplementedException();
        // }

        public void Save()
        {
            _Context.SaveChanges();
        }

        // public void UpdateCustomer(Core.Model.Customer customer)
        // {
        //     throw new NotImplementedException();
        // }
    }
}