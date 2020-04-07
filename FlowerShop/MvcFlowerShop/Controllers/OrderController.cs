using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFlowerShop.Data;
using MvcFlowerShop.Models;
using MvcFlowerShop.ViewModels;

namespace MvcFlowerShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly FlowersContext _context;

        public OrderController(FlowersContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var flowersContext = _context.Order.Include(o => o.Customer).Include(o => o.Store);
            return View(await flowersContext.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.Store)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "FirstName");
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "Address");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", "ProductPrice");
            return View();
            // var stores = _context.Store();
            // var customers = _context.Customer();
            // var products = _context.Product();

            // List<SelectListItem> choiceLocation = new List<SelectListItem>();
            // List<SelectListItem> choiceCustomer = new List<SelectListItem>();
            // List<SelectListItem> choiceProduct = new List<SelectListItem>();
            // ProductOrderViewModel view = new ProductOrderViewModel();
            // view = new ProductOrderViewModel
            // {
            //     LocationList = choiceLocation,
            //     CustomerList = choiceCustomer,
            //     ProductList = choiceProduct
            // };
            //  return View(view);
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,CustomerId,SaleDate,StoreId,OrderTotal")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "FirstName", order.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "Address", order.StoreId);
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "FirstName", order.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "Address", order.StoreId);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,CustomerId,SaleDate,StoreId,OrderTotal")] Order order)
        {
            if (id != order.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "FirstName", order.CustomerId);
            ViewData["StoreId"] = new SelectList(_context.Store, "StoreId", "Address", order.StoreId);
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.Store)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.SaleId == id);
        }
    }
}
