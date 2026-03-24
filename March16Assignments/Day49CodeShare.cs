
DbFirst approach of Entity Framework in asp.net core mvc  
*********************************************************

--->First Open mvc core app with 8.0 version 

--->add three dependencies using nugget package manager 8.0.24 version 


  Microsoft.EntityFrameworkCore
   Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools


--->then in package manager console fire this command 
 Scaffold-DbContext 'Data Source=LAPTOP-4G8BHPK9\SQLEXPRESS;initial catalog=NorthWind;Integrated Security=true;TrustServerCertificate=True;' 
 Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context NorthWindContext -Force


change above as per your server and as per your db okay 

so in models all classes will be generated 

frist add in models folder 

namespace DBFirstEFinAsp.netcoreDemo.Models
{
    public class SpainCustomerViewModel
    {
        public string Cid { get; set; }
        public string Cname { get; set; }
        public string Comname { get; set; }
    }
}

next 
using Microsoft.AspNetCore.Mvc;
using DBFirstEFinAsp.netcoreDemo.Models;

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
    }
}
next generate view using Cusotmer model only and go to view chnage as per SpainCustomerViewModel

@model IEnumerable<DBFirstEFinAsp.netcoreDemo.Models.SpainCustomerViewModel>

@{
    ViewData["Title"] = "SpainCustomers";
}

<h1>SpainCustomers</h1>

<p>
    <a asp-action="Create">Create New</a>
</p>
<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.Cid)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Comname)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Cname);
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Cid)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Comname)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Cname)
            </td>
                    </tr>
}
    </tbody>
</table>

next 

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
