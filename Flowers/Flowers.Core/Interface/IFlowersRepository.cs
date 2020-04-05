using System;
using System.Collections.Generic;
using System.Text;
using Flowers.Core.Model;


namespace Flowers.Core.Interface
{
    public interface IFlowersRepository
    {
        //  // get all customers with deffered execution
        // IEnumerable<Customer> GetCustomers(string search = null);

        // get a customer by ID
        Customer GetCustomerById(string Username);

       // Add a customer
        void AddCustomer (Customer customer );

        // // update a customer
        // void UpdateCustomer(Customer customer);

        // // add an order and associate it with a customer
        // void AddOrder(Order order, Customer customer = null);

        // persist changes to the data resource
        void Save();

    }
}