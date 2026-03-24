using Microsoft.AspNetCore.Mvc;
using DBFirstEFinAsp.netcoreDemo.Models;
using System.Security.Cryptography.Xml;

namespace DBFirstEFinAsp.netcoreDemo.Controllers
{

   
    public class NorthWiindController : Controller
    {
        public IActionResult SpainCustomers()
        {
                    NorthWindContext cnt = new NorthWindContext();
                    var spainCustomers = cnt.Customers
            .Where(x => x.Country == "Spain")
            .Select(x => new SpainCustomerViewModel
            {
                Cid = x.CustomerId,
                Cname = x.ContactName,
                Comname = x.CompanyName
            })
            .ToList();


            return View(spainCustomers);
                
        }
        // this will also work without SpainCustomerViewModel
        public IActionResult SpainCustomers2()
        {
            NorthWindContext cnt = new NorthWindContext();
            var spainCustomers = cnt.Customers
    .Where(x => x.Country == "Spain")
    .Select(x => new Customer
    {
        CustomerId = x.CustomerId,
        ContactName = x.ContactName,
        CompanyName = x.CompanyName
    })
    .ToList();


            return View(spainCustomers);

        }

        public IActionResult searchCustomer(string contactname)
        {
            NorthWindContext cnt = new NorthWindContext();
            var searchcustomer = from customer in cnt.Customers
                                 where customer.ContactName == contactname
                                 select new Customer
                                 {
                                     ContactName=customer.ContactName,
                                     ContactTitle=customer.ContactTitle,
                                     CompanyName=customer.CompanyName

                                 };
            var searchcustomer2 = cnt.Customers.Where(x => x.
            ContactName == contactname)
                .Select(x => new Customer { ContactName=x.ContactName,
                    ContactTitle=x.ContactTitle,CompanyName=x.CompanyName
                });
            var query1 = searchcustomer.Single();// can also use searchcustomer2
            var query2 = searchcustomer2.Single();
            return View(query1);// or query2 can be used 

        }

        public ActionResult ProductsInCategory(string categoryname)
        {
            NorthWindContext cnt = new NorthWindContext();
            var productsinCategory = cnt.Products.
                Where(x => x.Category.CategoryName == categoryname).
                Select(x => new ProdCat
                {
                prodname=x.ProductName,
                catname=x.Category.CategoryName

                }).ToList();
            return View(productsinCategory);
        }
        public ActionResult OrderRange(string range)
        {
            NorthWindContext cnt = new NorthWindContext();
            var range1 = Convert.ToInt16(range);
            var custOrderCount = cnt.Customers
                .Where(x => x.Orders.Count > range1).
                Select(x => new Customer
                {
                    CustomerId = x.CustomerId,
                    ContactName = x.ContactName,
                    

                });
            return View(custOrderCount);
                
        }


        
    }
}
