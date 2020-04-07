// using System;
// using System.Collections.Generic;
// using MvcFlowerShop.Models;
// using MvcFlowerShop.Interface;
// using Microsoft.EntityFrameworkCore;
// using System.Linq;

// namespace MvcFlowerShop.Repository
// {
//     public class FlowerShopRepository : IFlowerShopRepository
//     {
//          private readonly FlowersContext _Context;
//         public FlowersRepository(FlowersContext Context)
//         {
//             _Context = Context ?? throw new ArgumentException(nameof(Context));
//         }
//         public void AddCustomer(Model.Customer customer)
//         {
//             Customer entity = Mapper.MapCustomer(customer);
//             _Context.Add(entity);
//         }

//         public Model.Customer GetCustomerById(string userName)
//         {
//             var customer = _Context.Customer
//                 .FirstOrDefault(c => c.Username == userName);
//             if(customer != null)
//             {
//                 return Mapper.MapCustomer(customer);
//             }
//             return null;
//         }

//         public void Save()
//         {
//             _Context.SaveChanges();
//         }

//     }
// }