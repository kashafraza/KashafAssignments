
code first approach steps :
---------------------------
1)Installing packages core package ,tools,sql server 8.0.24 version install these dependencies 
    Microsoft.EntityFrameworkCore
   Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools
    
2)creating classes in Models folder which will later will 
be converted to db tables as i am using code first apprach  

and now add followng classes in Models folder 
 
Add Author,Course and Student classes into the
Models folder and then define the proeprties in them which i provide here okay 

between course and author there is one to many relationship means author
is master and course is child 
and between course and student many to many becauee one student can
take many course and in each course there will be many studnets so here 
junction table will be created with two one to many relationships okay 



namespace CodeFirstEntityFrameworkDemo.Models
{
    public class Author
    {
        public int Id { get; set; } // it will create identity column
        public string? AuthorName { set;get; }

        public IList<Course> Courses { get; set; }
    }
}

namespace CodeFirstEntityFrameworkDemo.Models
{
    public class Course
    {

        public int Id { get; set; } 
       
       public string? Title { get; set; }  

        public string? CourseDescription { get; set; }  

        public float? fullprice { get; set; }

        public Author? Author { get; set; }

        public List<Student> Students { get; set; } 

    }
}

namespace CodeFirstEntityFrameworkDemo.Models
{
    public class Student
    {
        public int Id { get; set; }

        public    List<Course> Courses { get; set; } 
    }
}



go to app settings and put comma and then
paste this code and modify as per your system settinggs

 "ConnectionStrings": {
   "constring": "Data Source=LAPTOP-4G8BHPK9\\SQLEXPRESS;initial catalog=EventCG;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;"
 }
 here it will look like this
 
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "constring": "Data Source=LAPTOP-4G8BHPK9\\SQLEXPRESS;initial catalog=EventCG;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;"
  }

}

context class also u need to create and in that u have to add all classes 
   and set the path in app  settings file and 
   also in program.cs file also inject the dependency 
   
   Now add one class like this EventContext which is master class which will 
   hold all tables through this only i will call other classes and tables 

   
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions dbContextOptions):
            base(dbContextOptions)
        {
            
        }
        public DbSet<Author> authors { set; get; }
        public DbSet<Course> courses { set; get; }

        public DbSet<Student> students { set; get; }
    }
}



now in program.cs i have to inject this dependency 

 builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

Now Build the solution once and start running the migrations 

Now i want to add some more classes into the same program but with annotations
which will provide valdiation to me accordingly constraints will be imposed on the table from 
 the classes 
 
 so some classes i will be adding and again same commands i will be using 
 
 so now add classes Author1 ,Course1 ,Employee ,UserDetail into the models folder 
 
namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class Author1
    {
        public int Id { set; get; }
        public string Name { get; set; }

        public IList<Course1> Courses { set; get; }
    }
}


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class Course1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }

        [Required]
        [Column("Stitle",TypeName ="varchar")]
        public string Title { set; get; }

        [Required]
        [MaxLength(220)]
        public string Description { set; get; }

        public float fullprice { set; get; }

        public Author1 Author { set; get; }

        [ForeignKey("Author")]
        public int AuthorId { set; get; }
     }
}

using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class Employee
    {
        public int Id { set; get; }

        [Required(ErrorMessage ="please enter your first name ")]
        public string FirstName { set; get; }

        [Required(ErrorMessage = "please enter your last name ")]
        public string LastName { set; get; }

        [Required(ErrorMessage = "please enter your email  ")]
        [EmailAddress(ErrorMessage ="enter valid email")]
        public string Email { set; get; }

        [Required(ErrorMessage="enter your age ")]
        [Range(0,100,ErrorMessage ="please enter age between 1 to 100 only ")]
        public int Age { set; get; }

    }
}


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class UserDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        [StringLength(15, ErrorMessage = "User Name cannot be more than 15 characters")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Minimum Length of Password is 5 letters or Max Length is of 11 letters..")]
        [DataType("password")]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Date Of Birth is Required")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Id")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Postal Code is Required")]
        [Range(100, 1000, ErrorMessage = "Must be between 100 and 1000")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [DisplayName("Phone Number")]
        public int PhoneNo { get; set; }

        [Required(ErrorMessage = "Profile is Required")]
        [DataType(DataType.MultilineText)]
        public string Profile { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions dbContextOptions):
            base(dbContextOptions)
        {
            
        }
        public DbSet<Author> authors { set; get; }
        public DbSet<Course> courses { set; get; }

        public DbSet<Student> students { set; get; }

        public DbSet<Author1> authors1 { set; get; }

        public DbSet<Course1> courses1 { set; get; }

        public DbSet<Employee> employees { set; get; }

        public DbSet<UserDetail> userdetails { set; get; }
    }
}

Now build the solution 

and then add migrations 

Now add some values in employees tabe like this 

    fill some data in employees table from 

+----+-----------+----------+------------------------+-----+
| Id | FirstName | LastName |         Email          | Age |
+----+-----------+----------+------------------------+-----+
| 1  | Kiran     | shukla   | kiran@gmail.com        | 34  |
| 2  | Mahesh    | Babu     | Mahesh@gmail.com       | 39  |
| 3  | Sita      | Dinakar  | dinakar@yahoo.com      | 32  |
+----+-----------+----------+------------------------+-----+

go to home controller 

using System.Diagnostics;
using CodeFirstEFInAsp.netcoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstEFInAsp.netcoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventContext _context;

        public HomeController(ILogger<HomeController> logger,
            EventContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult displayemp()
        {
            var employees = _context.employees.ToList();
            return View(employees);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


and view for it 

@model IEnumerable<CodeFirstEFInAsp.netcoreDemo.Models.Employee>

@{
    ViewData["Title"] = "displayemp";
}

<h1>displayemp</h1>

<p>
    <a asp-action="Create">Create New</a>
</p>
<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.FirstName)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.LastName)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Email)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Age)
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.FirstName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.LastName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Email)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Age)
            </td>
            <td>
                <a asp-action="Edit" asp-route-id="@item.Id">Edit</a> |
                <a asp-action="Details" asp-route-id="@item.Id">Details</a> |
                <a asp-action="Delete" asp-route-id="@item.Id">Delete</a>
            </td>
        </tr>
}
    </tbody>
</table>


next add create get and post methods 

[HttpGet]
public IActionResult Create()
{
    return View();
}
[HttpPost]
public IActionResult Create(Employee employee)
{
    if(ModelState.IsValid)
    {
        _context.employees.Add(employee);
        _context.SaveChanges();
        return RedirectToAction("displayemp");
    }
    return View(employee);
}
view for create 
----------------
@model CodeFirstEFInAsp.netcoreDemo.Models.Employee

@{
    ViewData["Title"] = "Create";
}

<h1>Create</h1>

<h4>Employee</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Create">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="FirstName" class="control-label"></label>
                <input asp-for="FirstName" class="form-control" />
                <span asp-validation-for="FirstName" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="LastName" class="control-label"></label>
                <input asp-for="LastName" class="form-control" />
                <span asp-validation-for="LastName" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Email" class="control-label"></label>
                <input asp-for="Email" class="form-control" />
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Age" class="control-label"></label>
                <input asp-for="Age" class="form-control" />
                <span asp-validation-for="Age" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Create" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Back to List</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}

details view 
------------
   public IActionResult Details (int id)
   {
       var employee = _context.employees.FirstOrDefault(e => e.Id == id);
       if(employee==null)
       {
           return NotFound();
       }
       return View(employee);
   }

@model CodeFirstEFInAsp.netcoreDemo.Models.Employee

@{
    ViewData["Title"] = "Details";
}

<h1>Details</h1>

<div>
    <h4>Employee</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.FirstName)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.FirstName)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.LastName)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.LastName)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Email)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Email)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Age)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Age)
        </dd>
    </dl>
</div>
<div>
    <a asp-action="Edit" asp-route-id="@Model?.Id">Edit</a> |
    <a asp-action="displayemp">Back to List</a>
</div>

edit action methd 
-----------------
    public IActionResult Edit(int id)
    {
        var employee = _context.employees.Find(id);
        if(employee==null)
        {
            return BadRequest();
        }
        return View(employee);
    }
    [HttpPost]
    public IActionResult Edit(int id,Employee employee)
    {
        if(id!=employee.Id)
        {
            return BadRequest();
        }
        if(ModelState.IsValid)
        {
            _context.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("displayemp");
        }
        return View(employee);
    }



@model CodeFirstEFInAsp.netcoreDemo.Models.Employee

@{
    ViewData["Title"] = "Edit";
}

<h1>Edit</h1>

<h4>Employee</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Edit">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <input type="hidden" asp-for="Id" />
            <div class="form-group">
                <label asp-for="FirstName" class="control-label"></label>
                <input asp-for="FirstName" class="form-control" />
                <span asp-validation-for="FirstName" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="LastName" class="control-label"></label>
                <input asp-for="LastName" class="form-control" />
                <span asp-validation-for="LastName" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Email" class="control-label"></label>
                <input asp-for="Email" class="form-control" />
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Age" class="control-label"></label>
                <input asp-for="Age" class="form-control" />
                <span asp-validation-for="Age" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Save" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="displayemp">Back to List</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
 
 public IActionResult Delete(int id)
 {
     var employee = _context.employees.Find(id);
     if (employee == null)
     {
         return NotFound();
     }
     return View(employee);
 }


 // POST: Employee/Delete/5
 [HttpPost, ActionName("Delete")]
 [ValidateAntiForgeryToken]
 public IActionResult DeleteConfirmed(int id)
 {
     var employee = _context.employees.Find(id);
     if (employee != null)
     {
         _context.employees.Remove(employee);
         _context.SaveChanges();
     }
     return RedirectToAction("displayemp");
 }


@model CodeFirstEFInAsp.netcoreDemo.Models.Employee

@{
    ViewData["Title"] = "Delete";
}

<h1>Delete</h1>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Employee</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.FirstName)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.FirstName)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.LastName)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.LastName)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Email)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Email)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Age)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Age)
        </dd>
    </dl>
    
    <form asp-action="Delete">
        <input type="hidden" asp-for="Id" />
        <input type="submit" value="Delete" class="btn btn-danger" /> |
        <a asp-action="displayemp">Back to List</a>
    </form>
</div>
------------------------
using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class Customer
    {
        public int CustomerID { set; get; }

        [Required]
        public string CustomerName { set; get; }

        public ICollection<Product> Products { set; get; }
    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public string ProductName { set; get; }

        [Display(Name ="who buyed")]
        [ForeignKey("Customer")]
        public int CustomerID { set; get; }

       
        public Customer Customer { set; get; }
    }
}


adding in event context 

using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions dbContextOptions):
            base(dbContextOptions)
        {
            
        }
        public DbSet<Author> authors { set; get; }
        public DbSet<Course> courses { set; get; }

        public DbSet<Student> students { set; get; }

        public DbSet<Author1> authors1 { set; get; }

        public DbSet<Course1> courses1 { set; get; }

        public DbSet<Employee> employees { set; get; }

        public DbSet<UserDetail> userdetails { set; get; }

        public DbSet<Customer> Customers { set; get; }

        public DbSet<Product> Products { set; get; }
    }
}


build the application 

run migrations 

using CodeFirstEFInAsp.netcoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstEFInAsp.netcoreDemo.Controllers
{
    public class TransactionController : Controller
    {
        private readonly EventContext _context;
        public TransactionController(EventContext context)
        {
            _context = context;
        }

        public IActionResult  CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer )
        {
            if(ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Content("customer added");
              //  return RedirectToAction("CreateProduct");
            }
            return View(customer);
        }
    }
}

@model CodeFirstEFInAsp.netcoreDemo.Models.Customer
@{
    ViewData["Title"] = "CreateCustomer";
}

<h1>CreateCustomer</h1>

<form asp-action="CreateCustomer" method="Post">
    
    <div class="form-group">
        <label asp-for="CustomerName" class="control-label"></label>
        <input asp-for="CustomerName" class="form-control" />
        <span asp-validation-for="CustomerName" class="text-danger"></span>
    </div>

    <button type="submit" class="btn btn-primary">Save</button>
</form>

 public IActionResult CreateProduct(int? customerId=null)
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
            if(ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction
                    ("CreateProduct", new { customerId = product.CustomerID });
            }
            // preserving values 
            ViewBag.customerId = product.CustomerID;
            ViewBag.CustomerList = new SelectList(_context.Customers,
               "CustomerID", "CustomerName",product.CustomerID);
            return View(product);
        }



@model CodeFirstEFInAsp.netcoreDemo.Models.Product;
@{
    ViewData["Title"] = "CreateProduct";
}

<h1>CreateProduct</h1>

<form asp-action="CreateProduct" method="post">
    <div>
        <label asp-for="ProductName"></label>
        <input asp-for="ProductName" />
        <span asp-validation-for="ProductName"></span>
    </div>

    <div>
        <label asp-for="CustomerID">Who Buyed</label>
        <select asp-for="CustomerID" asp-items="ViewBag.CustomerList">
            <option value="">-- Select Customer --</option>
        </select>
        <span asp-validation-for="CustomerID"></span>
    </div>

    <button type="submit">Save</button>
</form>

<div class="mt-3">
    @{
        var selectedCustomerId = 0;
        if (ViewBag.CustomerId != null)
        {
            selectedCustomerId = (int)ViewBag.CustomerId;
        }
        else if (Model?.CustomerID > 0)
        {
            selectedCustomerId = Model.CustomerID;
        }
    }
    @if (selectedCustomerId > 0)
    {
        <a asp-action="Summary" asp-route-customerId="@selectedCustomerId" class="btn btn-primary">
            Checkout / View Summary
        </a>
        <small class="text-muted">for Customer ID: @selectedCustomerId</small>
    }
    else
    {
        <small class="text-warning">Select a customer first</small>
    }
</div> 

----------write in controller ---------
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

view for this 
    -------------------------summary.cshtml-------

    @model CodeFirstEFDEmo.Models.Customer

@{
    ViewData["Title"] = "Checkout Summary";
}

<h2>Checkout Summary for @Model.CustomerName</h2>
<p>Total Products Bought: @Model.Products.Count</p>

<div class="table-responsive">
    <table class="table table-striped">
        <thead>
            <tr>
                <th>Product Name</th>
                <th>Who Bought</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var product in Model.Products)
            {
                <tr>
                    <td>@product.ProductName</td>
                    <td>@product.Customer.CustomerName</td>
                </tr>
            }
        </tbody>
    </table>
</div>

<div class="mt-3">
    <a asp-action="CreateProduct" asp-route-customerId="@Model.CustomerID" class="btn btn-secondary">Add More Products</a>
    <button class="btn btn-success" onclick="alert('Checkout Complete! Thank you, @Model.CustomerName.'); window.location.href='@Url.Action("CreateCustomer")';">
        Checkout Complete
    </button>
</div>

