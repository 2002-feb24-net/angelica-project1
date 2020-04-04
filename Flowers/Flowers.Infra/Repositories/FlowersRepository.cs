using System;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Flowers.Core.Interface;
using Flowers.Infra.Entities;
using System.Collections.Generic;

namespace Flowers.Infra.Repositories
{
    public class FlowersRepository : IFlowersRepository
    {
        public void AddCustomer(Core.Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        public Core.Model.Customer GetCustomerById(string Username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Model.Customer> GetCustomers(string search = null)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Core.Model.Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}