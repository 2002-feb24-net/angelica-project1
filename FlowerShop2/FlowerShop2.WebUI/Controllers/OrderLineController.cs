using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerShop2.DataAccess;
using FlowerShop2.Domain.Model;

namespace FlowerShop2.WebUI.Controllers
{
    public class OrderLineController : Controller
    {
        private readonly FlowersContext _context;

        public OrderLineController(FlowersContext context)
        {
            _context = context;
        }

        // GET: OrderLine
        public async Task<IActionResult> Index()
        {
            var flowersContext = _context.OrderLine.Include(o => o.Inventory).Include(o => o.Product).Include(o => o.Sale);
            return View(await flowersContext.ToListAsync());
        }

        // GET: OrderLine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLine = await _context.OrderLine
                .Include(o => o.Inventory)
                .Include(o => o.Product)
                .Include(o => o.Sale)
                .FirstOrDefaultAsync(m => m.OrderLineId == id);
            if (orderLine == null)
            {
                return NotFound();
            }

            return View(orderLine);
        }

        // GET: OrderLine/Create
        public IActionResult Create()
        {
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName");
            ViewData["SaleId"] = new SelectList(_context.Order, "SaleId", "SaleId");
            return View();
        }

        // POST: OrderLine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderLineId,Quantity,SaleId,ProductId,InventoryId")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", orderLine.InventoryId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", orderLine.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Order, "SaleId", "SaleId", orderLine.SaleId);
            return View(orderLine);
        }

        // GET: OrderLine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLine = await _context.OrderLine.FindAsync(id);
            if (orderLine == null)
            {
                return NotFound();
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", orderLine.InventoryId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", orderLine.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Order, "SaleId", "SaleId", orderLine.SaleId);
            return View(orderLine);
        }

        // POST: OrderLine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderLineId,Quantity,SaleId,ProductId,InventoryId")] OrderLine orderLine)
        {
            if (id != orderLine.OrderLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderLineExists(orderLine.OrderLineId))
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
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", orderLine.InventoryId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", orderLine.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Order, "SaleId", "SaleId", orderLine.SaleId);
            return View(orderLine);
        }

        // GET: OrderLine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLine = await _context.OrderLine
                .Include(o => o.Inventory)
                .Include(o => o.Product)
                .Include(o => o.Sale)
                .FirstOrDefaultAsync(m => m.OrderLineId == id);
            if (orderLine == null)
            {
                return NotFound();
            }

            return View(orderLine);
        }

        // POST: OrderLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderLine = await _context.OrderLine.FindAsync(id);
            _context.OrderLine.Remove(orderLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderLineExists(int id)
        {
            return _context.OrderLine.Any(e => e.OrderLineId == id);
        }
    }
}
