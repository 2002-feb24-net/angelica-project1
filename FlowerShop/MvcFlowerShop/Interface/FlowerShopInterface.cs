using System;
using System.Collections.Generic;
using MvcFlowerShop.Models;
using System.Text;

namespace MvcFlowerShop.Interface
{
    public interface FlowerShopInterface
    {
        Customer GetCustomerById(string Username);
        void AddCustomer(Customer customer);
        void DeleteCustomer();
        void UpdateCustomer(Customer customer);

        void Save();
    }
}