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
          new Employee{ EmployeeID=101,EmpName="ravi" ,Salary=34000,ImageUrl="/images/pic1.jpg",DeptID=30},
           new Employee{ EmployeeID=102,EmpName="sita" ,Salary=64000,ImageUrl="/images/pic2.jpg",DeptID=20},
          
           new Employee{ EmployeeID=103,EmpName="Mahesh" ,Salary=67000,ImageUrl="/images/boy2.jpg",DeptID=10},
		    new Employee{ EmployeeID=104,EmpName="shanti" ,Salary=44000,ImageUrl="/images/girls2.jpg",DeptID=10},

        };

        public IActionResult collectionofdepts ()
        {
            return View(deptlist);
        }
        public IActionResult EmpsInDept(int deptid)
        {
            var employees = emplist.Where(e => e.DeptID == deptid).ToList();
            return View(employees);
            
        }

        List<Dept> deptlist = new List<Dept>()
        {
         new Dept{DeptID=10,DeptName="Sales"},
         new Dept{DeptID=20,DeptName="HR"},
         new Dept{DeptID=30,DeptName="Software"}


        };
        public IActionResult mixedobjectpassing(int empid)
        {
            var query1 = deptlist.ToList();
            Employee emp = emplist.
                Where(x => x.EmployeeID == empid).FirstOrDefault();
            var query2 = emp;
            EmpdeptViewModel obj = new EmpdeptViewModel()
            {
                deptlist=query1,
                emp=query2,
                date=DateTime.Now

            };
            return View(obj);
        }


        public IActionResult Details(int id)
        {
          var employee = emplist.FirstOrDefault(e => e.EmployeeID == id);
           if(employee==null)
            {
                return NotFound();
            }
            return View(employee);

        }
        public IActionResult searchemp(int empid)
        {
            Employee emp = (from e1 in emplist
                            where
                          e1.EmployeeID == empid
                            select e1).FirstOrDefault();
            return View(emp);
        }
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
