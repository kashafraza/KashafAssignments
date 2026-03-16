using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCExampleDemo.Models;

namespace MVCExampleDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string sampledemo1()
        {
            return "Raghavendra Ponde";
        }
        public string sampledemo2(int age,string name)
        {
            return "The name " + name + "and having age " + age;
        }
        public IActionResult sampledemo3()
        {
            int age = 34;
            string name = "ravi kumar";
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewData["Message"] = "Welcome to Asp.net core learning";
            ViewData["Year"] = DateTime.Now.Year;
            return View();
        }
        Employee obj = new Employee()
        {
            EmployeeID = 101,
            EmpName = "ravi",
            Salary = 34000
        };
        List<Employee> emplist = new List<Employee>()
        {
          new Employee{ EmployeeID=101,EmpName="ravi" ,Salary=34000,ImageUrl="/images/pic1.jpg"},
           new Employee{ EmployeeID=102,EmpName="sita" ,Salary=64000,ImageUrl="/images/pic2.jpg"},
           new Employee{ EmployeeID=103,EmpName="ravi2" ,Salary=24000,ImageUrl="/images/pic1.jpg"},
           new Employee{ EmployeeID=102,EmpName="sita2" ,Salary=74000,ImageUrl="/images/pic2.jpg"},

        };
        public IActionResult collectionofobjectspassing()
        {
            return View(emplist);
        }
        public IActionResult singleobjectpassing()
        {
            return View(obj);
        }
        public IActionResult display()
        {
            return View();
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
