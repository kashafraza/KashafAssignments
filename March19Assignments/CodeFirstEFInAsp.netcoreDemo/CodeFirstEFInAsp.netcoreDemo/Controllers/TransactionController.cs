using CodeFirstEFInAsp.netcoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CodeFirstEFInAsp.netcoreDemo.Controllers
{
    public class TransactionController : Controller
    {
        private readonly EventContext _context;
        public TransactionController(EventContext context)
        {
            _context = context;
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            ModelState.Clear();
            ModelState.Remove(nameof(customer.CustomerID));
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                //  return Content("customer added");
                return RedirectToAction("CreateProduct",
                    new { customerId = customer.CustomerID });
            }
            return View(customer);
        }
        public IActionResult CreateProduct(int? customerId = null)
        {
            var cid = customerId ?? 0;
            ViewBag.CustomerId = cid;
            ViewBag.CustomerList = new SelectList(_context.Customers,
                "CustomerID", "CustomerName", cid);
            return View();

        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            ModelState.Clear();
            ModelState.Remove(nameof(product.ProductID));
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction
                    ("CreateProduct", new { customerId = product.CustomerID });
            }
            // preserving values 
            ViewBag.customerId = product.CustomerID;
            ViewBag.CustomerList = new SelectList(_context.Customers,
               "CustomerID", "CustomerName", product.CustomerID);
            return View(product);
        }

        public IActionResult Summary(int customerId)
        {
            var customer = _context.Customers
                .Include(c => c.Products)
                .FirstOrDefault(c => c.CustomerID == customerId);

            if (customer == null || !customer.Products.Any())
            {
                return RedirectToAction("CreateProduct", new { customerId });
            }

            return View(customer);
        }

    }
        
    
}
