using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlowerShop2.Domain;
using FlowerShop2.Domain.Model;
using FlowerShop2.WebUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlowerShop2.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _context;
        private readonly ICustomerRepository _customerContext;
        private readonly IStoreRepository _storeContext;
        public OrderController(IOrderRepository orderRepo, ICustomerRepository customerRepo, IStoreRepository storeRepo)
        {
            _context = orderRepo;
            _customerContext = customerRepo;
            _storeContext = storeRepo;

        }
        // GET: Order
        // public IActionResult Index()
        // {
        //     var flowerContext = _context.GetOrders();
        //     return View(flowerContext.ToList());
        // }
        public async Task<IActionResult> Index()
        {
            var flowerContext = await _context.GetOrders();
            return View(flowerContext.ToList());
        }
        // private PlaceOrderViewModel InitPOVM(int storeID)
        // {
        //     TempData["StoreId"] = storeID;
        //     var inventoryItemModel = new PlaceOrderViewModel
        //     {
        //         Inventory = _storeContext.GetInventory(storeID)
        //     };
        //     ViewData["ProductId"] = new SelectList(_storeContext.GetInventory(storeID),"ProductId","ProductName");
        //     return inventoryItemModel;
        // }
        private bool AddOrderItem(OrderLine item)
        {
            int storeID = Convert.ToInt32(TempData["StoreId"]);
            TempData["StoreId"] = storeID;
            int orderID = Convert.ToInt32(TempData["OrderId"]);
            TempData["OrderId"] = orderID;


            if (ModelState.IsValid && item.ValidateQuantity(_storeContext.GetQuantity(item.ProductId)))
            {
                _storeContext.UpdateInventory(item.ProductId, item.Quantity);
                item.SaleId=orderID;
                _context.AddOrderLine(item);
                return true;
            }
            ModelState.AddModelError("QuantityError", "Invalid quantity");
            return false;
        }

        // public IActionResult AddMore([Bind("SaleId", "Quantity","OrderLineId","ProductId")]OrderLine item)
        // {
        //     if(!AddOrderItem(item))
        //     {
        //         TempData["ItemAddError"] = true;
        //     }
        //     int storeID = Convert.ToInt32(TempData["StoreId"]);
        //     InitPOVM(storeID);
        //     return RedirectToAction("CreateOrderItem");
        // }
        // public IActionResult CreateOrderItem()
        // {
        //     if (TempData["ItemAddError"]!= null && (bool)TempData["ItemAddError"]== true)
        //     {
        //         ModelState.AddModelError("Quantity Error","Item not added");
        //     }
        //     int storeID = Convert.ToInt32(TempData["StoreID"]);
        //     TempData["StoreID"] = storeID;
        //     return View(InitPOVM(storeID));
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public IActionResult CreateOrderItem([Bind("SaleId", "Quantity","OrderLineId","ProductId")]OrderLine item)
        // {
        //     if (AddOrderItem(item))
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ModelState.AddModelError("QuantityError", "Invalid quantity");
        //     int storeID = Convert.ToInt32(TempData["StoreId"]);
        //     return View(InitPOVM(storeID));
        // }


        // GET: Order/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.FindByID(Convert.ToInt32(id));
            if (order == null)
            {
                return NotFound();
            }
            return View(order);

        }


        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.GetStores(), "StoreId", "State");
            ViewData["ProductId"] = new SelectList(_context.GetProducts(),"ProductId","ProductName");
            ViewData["CustomerId"] = new SelectList(_context.GetCustomers(),"CustomerId","Username");
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OrderLineId","CustomerId","StoreId","CustomerId")] OrderViewModel order)
        {
            if (ModelState.IsValid)
            {

                Order new_order = new Order
            {
                StoreId = order.StoreId,
                CustomerId = order.CustomerId,
                SaleDate = DateTime.Now,
                OrderTotal = 0,
            };
          TempData["OrderID"] = _context.Create(new_order);
          TempData["StoreId"] = order.StoreId;
          return RedirectToAction("Create");
        }
        else
        {
            TempData["VerificationError"] = true;
        }
        return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.FindByID(Convert.ToInt32(id));
            if(order == null)
            {
                return NotFound();
            }
            IEnumerable<Customer> custEnum = await _customerContext.GetCustomers();
            ViewData["CustomerId"] = new SelectList(custEnum, "CustomerId","Username",order.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.GetStores(),"Id", "Name", order.StoreId);
            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId", "CustomerId", "StoreId", "OrderTotal")] Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Edit(order);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.SaleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<Customer> custEnum = await _customerContext.GetCustomers();
            ViewData["CustomerId"] = new SelectList(custEnum, "CustomerId","Username",order.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.GetStores(),"Id", "Name", order.StoreId);
            return View(order);


        }

        // GET: Order/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.FindByID(Convert.ToInt32(id));
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var order = _context.FindByID(id);
            _context.Remove(order.SaleId);
            return RedirectToAction(nameof(Index));

        }
         private bool OrderExists(int id)
        {
            return !(_context.FindByID(id) == null);
        }
    }
}