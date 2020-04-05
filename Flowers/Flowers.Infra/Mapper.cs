using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowers.Infra
{
    /// <summary>
    /// a mapper is a way to link the db entities in Flowers.Infra
    /// to the models in Flowers.Core
    /// </summary>
        public static class Mapper
    {
        public static Core.Model.Customer MapCustomer(Entities.Customer Customer)
        {
            return new Core.Model.Customer
            {
                CustomerId = Customer.CustomerId,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                Username = Customer.Username,

                Order = Customer.Order.Select(MapOrder).ToList()
            };
        }

        public static Entities.Customer MapCustomer(Core.Model.Customer Customer)
        {
            return new Entities.Customer
            {
                CustomerId = Customer.CustomerId,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                Username = Customer.Username,

                Order = Customer.Order.Select(MapOrder).ToList()
            };
        }

        public static Core.Model.Inventory MapInventory(Entities.Inventory Inventory)
        {
            return new Core.Model.Inventory
            {
                InventoryId = Inventory.InventoryId,
                StoreId = Inventory.StoreId,
                ProductId = Inventory.ProductId,
                InventoryCount = Inventory.InventoryCount,

            };
        }

        public static Entities.Inventory MapInventory(Core.Model.Inventory Inventory)
        {
            return new Entities.Inventory
            {
                InventoryId = Inventory.InventoryId,
                StoreId = Inventory.StoreId,
                ProductId = Inventory.ProductId,
                InventoryCount = Inventory.InventoryCount,

            };
        }

          public static Core.Model.Order MapOrder(Entities.Order Order)
        {
            return new Core.Model.Order
            {
                SaleId = Order.SaleId,
                CustomerId = Order.CustomerId,
                SaleDate = Order.SaleDate,
                StoreId = Order.StoreId,
                OrderTotal = Order.OrderTotal,

            };
        }

        public static Entities.Order MapOrder(Core.Model.Order Order)
        {
            return new Entities.Order
            {
                SaleId = Order.SaleId,
                CustomerId = Order.CustomerId,
                SaleDate = Order.SaleDate,
                StoreId = Order.StoreId,
                OrderTotal = Order.OrderTotal,

            };
        }

        public static Core.Model.Product MapProduct(Entities.Product Product)
        {
            return new Core.Model.Product
            {
                ProductId = Product.ProductId,
                ProductName = Product.ProductName,
                ProductPrice = Product.ProductPrice,

                Inventory= Product.Inventory.Select(MapInventory).ToList(),

            };
        }

        public static Entities.Product MapProduct(Core.Model.Product Product)
        {
            return new Entities.Product
            {
                ProductId = Product.ProductId,
                ProductName = Product.ProductName,
                ProductPrice = Product.ProductPrice,

                Inventory= Product.Inventory.Select(MapInventory).ToList(),

            };
        }


        public static Core.Model.Store MapStore(Entities.Store Store)
        {
            return new Core.Model.Store
            {
                StoreId = Store.StoreId,
                StoreName = Store.StoreName,
                Address = Store.Address,
                State = Store.State,
                City = Store.City,
                PostalCode = Store.PostalCode,

                Order = Store.Order.Select(MapOrder).ToList(),
                Inventory = Store.Inventory.Select(MapInventory).ToList()
            };
        }

        public static Entities.Store MapStore(Core.Model.Store Store)
        {
            return new Entities.Store
            {
                StoreId = Store.StoreId,
                StoreName = Store.StoreName,
                Address = Store.Address,
                State = Store.State,
                City = Store.City,
                PostalCode = Store.PostalCode,

                Order = Store.Order.Select(MapOrder).ToList(),
                Inventory = Store.Inventory.Select(MapInventory).ToList()
            };
        }



    }
}
