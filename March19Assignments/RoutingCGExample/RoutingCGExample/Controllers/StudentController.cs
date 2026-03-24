using Microsoft.AspNetCore.Mvc;
using RoutingCGExample.Models;
namespace RoutingCGExample.Controllers
{
    public class StudentController : Controller
    {
        List<Student> studlist = new List<Student>()
        {
            new Student {Id=101,Name="kiran",Class="class4"},

             new Student {Id=102,Name="Mohan",Class="class7"},
              new Student {Id=103,Name="Suhana",Class="class8"},
        };
        [Route("studs")]//attribute routing 
        public IActionResult GetAllStudents()
        {
            return View(studlist);
        }
        [Route("studs/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = studlist.FirstOrDefault(x => x.Id == id);
            return View(student);
        }
        [Route("studsfew")]
        public IActionResult fewcolumns()
        {
            var fewcolumns = studlist.Select(x => new Student
            {
                Class=x.Class,
                Name=x.Name
            });
            return View(fewcolumns);
        }
    }
}
