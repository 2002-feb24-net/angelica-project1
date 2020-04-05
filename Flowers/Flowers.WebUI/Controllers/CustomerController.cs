using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Flowers.Core.Model;
using Flowers.WebUI.Models;
using Microsoft.EntityFrameworkCore;
using Flowers.Infra.Entities;

namespace Flowers.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly FlowersContext _context;

        public CustomerController(FlowersContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Customer.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerId, FirstName, LastName, Username")] Core.Model.Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                _context.SaveChanges();
            };
            return View(customer);
        }
    }
}