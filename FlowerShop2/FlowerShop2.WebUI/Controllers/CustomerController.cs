using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlowerShop2.Domain;
using FlowerShop2.Domain.Model;


namespace FlowerShop2.WebUI.Controllers
{
    public class CustomerController : Controller

    {
        private readonly ICustomerRepository _context;

        public CustomerController(ICustomerRepository context)
        {
            _context = context;
        }
        // GET: Customer
        public async Task<IActionResult> Index()
        {
            TempData.Clear();
            return View(await _context.GetCustomers());
        }

        // GET: Customer/Details/5
         public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.FindByID(Convert.ToInt32(id));
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Create([Bind("CustomerId,Username,FirstName,LastName")] Customer customer)
        {

            if (ModelState.IsValid)
            {
                    _context.Create(customer);
                    return RedirectToAction(nameof(Index));
                }
                return View(customer);
        }


        // GET: Customer/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer =  _context.FindByID(Convert.ToInt32(id));
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       public IActionResult Edit(int id, [Bind("CustomerId,Username,FirstName,LastName")] Customer customer)
        {
            if (_context.FindByID(id).Username != customer.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);

                }
                catch (Exception)
                {
                    TempData["EditFailed"] = true;
                    ModelState.AddModelError("EditFailed", "Update failed");
                    return View(customer);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
         public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.FindByID(Convert.ToInt32(id));
            if (customer == null)
            {
                return NotFound();
            }


            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}