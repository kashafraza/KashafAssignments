As there is a problem i am entering in update two times the id which is not needed in this scenatios you can go for DTO (Data Trasfer objects) as per design i have to create the DTO 
and work okay 

You can let Swagger reuse the route {id} value as the model Id so you only type it once, by removing the Id from the form model and binding it only from the route.

1. Remove Id from the body model
If you do not want to type Id in the form body, do not expose it in Employee for update; make a separate DTO without Id:

Go to Models folder and add this class 

  public class EmployeeUpdateDto
{
    [Required(ErrorMessage = "Please enter your firstname")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your lastname")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Please enter email id")]
    [EmailAddress(ErrorMessage = "Please enter valid email id")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please enter your age")]
    [Range(0, 100, ErrorMessage = "Please enter your age betwen 1 to 100 only ")]
    public int Age { get; set; }

    public string? ImagePath { get; set; }
}

then use this class in EmpController remember DTO has to be used only in Controller dont use in EmployeeService and and again dont use in EmpController two two times and make the code complex so i mean to say 
use at one place either in service class or in controller 

[HttpPut("{id}")]
public async Task<ActionResult<Employee>> Update(
        int id,        [FromForm] EmployeeUpdateDto employeeDto,IFormFile? image)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        
            // map dto to entity
            var employee = new Employee
            {
                Id = id, // take from route only
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Age = employeeDto.Age,
                ImagePath = employeeDto.ImagePath
            };
        
            var updated = await _employeeService.UpdateEmployeeAsync(employee, image);
            if (updated == null)
                return NotFound("Employee not found to update");
        
            return Ok(updated);
        }

so after doing this much run the code and see the output everthing is working okay .

  Prompt : 
---------
I am in asp.net core mvc application and in controller folder only i had added 
API controller Now how do i show the data from     Web Api to MVC Controller
by using jquery ajax method for the above coding which i have done i want to use bootswatch Quartz theme here 

Go to layout of shared folder comment the normal available bootstrap css file and add the quartz css okay 

@*   <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" /> *@
  <link href="https://cdn.jsdelivr.net/npm/bootswatch@5.3.2/dist/quartz/bootstrap.min.css" rel="stylesheet">

My layout i had changed  like this .
-------------------------------------
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - CodeFirstEFDEmo</title>
   @*  <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" /> *@
    <link href="https://cdn.jsdelivr.net/npm/bootswatch@5.3.2/dist/quartz/bootstrap.min.css" rel="stylesheet">


   <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
    <link rel="stylesheet" href="~/CodeFirstEFDEmo.styles.css" asp-append-version="true" />
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container-fluid">
                <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">CodeFirstEFDEmo</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
    <div class="container">
        <main role="main" class="pb-3">
            @RenderBody()
        </main>
    </div>

    <footer class="border-top footer text-muted">
        <div class="container">
            &copy; 2025 - CodeFirstEFDEmo - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="~/js/site.js" asp-append-version="true"></script>
    @await RenderSectionAsync("Scripts", required: false)


    @section Scripts {
        @{
            await Html.RenderPartialAsync("_ValidationScriptsPartial");
        }
    }

</body>
</html>


Then in the HomeController add Index2 method like this remember when u are 
actually doing the project the the name u give it as EmpUIController which is consuming the web api 

 public IActionResult Index2()
 {
     return View();
 }

generate an empty view for the above method and remove the default design for it okay 

Demoweb api controller  i had written the code directly and at that time image were not uploaded 
and demo controller normal crud operations are there here 

run the web api of DemoController and take the url  of Demo get methd 


https://localhost:7003/api/Demo

now  paste this desing 


@{
    ViewData["Title"] = "Employee Directory";
}

<div class="container mt-4">
    <div class="card shadow">
        <div class="card-header bg-primary text-white">
            <h4><i class="bi bi-people-fill"></i> Employee Directory</h4>
        </div>
        <div class="card-body">
            <table class="table table-hover table-bordered text-center" id="employeeTable">
                <thead class="table-dark">
                    <tr>
                        <th>Image</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
    </div>
</div>

@section Scripts {
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">
    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script>
        $(document).ready(function () {
            loadEmployees();
        });

        function loadEmployees() {
            $.ajax({
                url: 'https://localhost:7267/api/Demo',
                type: 'GET',
                success: function (data) {
                    var tbody = $("#employeeTable tbody");
                    tbody.empty();

                    $.each(data, function (i, emp) {
                        var row = `<tr>
                                    <td><img src="${emp.imageUrl}" class="img-thumbnail rounded-circle" width="60" height="60" /></td>
                                    <td>${emp.firstName}</td>
                                    <td>${emp.lastName}</td>
                                    <td><i class="bi bi-envelope-fill text-primary"></i> ${emp.email}</td>
                                </tr>`;
                        tbody.append(row);
                    });
                },
                error: function (xhr, status, error) {
                    alert("Failed to load data: " + error);
                }
            });
        }
    </script>
}

Now add one default image which i have given in whats app into uploads folder and give name as default.jpg 

In order to take full path of image means obsolute path add this into the code 

 private readonly IHttpContextAccessor _httpContextAccessor;

 public EmployeeService(EventContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
 {
     _context = context;
     _env = env;
     _httpContextAccessor = httpContextAccessor;
 }

also in program.cs 
add it liek this 

  var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

add this method in employeeservice 

   public string GetBaseUrl()
   {
       var httpContext = _httpContextAccessor.HttpContext;
       if (httpContext == null) throw new InvalidOperationException("No HttpContext");
       var request = httpContext.Request;
       return $"{request.Scheme}://{request.Host}";
   }
chnage this method in employeeservice
-----------------------------
 public async Task<List<Employee>> GetAllEmployeesAsync(int pageNumber,int pageSize)
 {
     var employees = await _context.employees.
         Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

     string baseUrl = GetBaseUrl();
     foreach(var e in employees)
     {
         e.ImagePath = string.IsNullOrEmpty(e.ImagePath) ?
             baseUrl + "/uploads/default.jpg" : baseUrl + e.ImagePath;
     }
     return employees;
     
 }
change here also 
private void DeleteImageFile(string? imagePath)
{
    if (string.IsNullOrEmpty(imagePath)||imagePath.Contains("default.jpg"))// added here code 
        return;

    var fullPath = Path.Combine
        (_env.WebRootPath, imagePath.TrimStart('/').Replace
        ('/', Path.DirectorySeparatorChar));
    if (File.Exists(fullPath))
    {
        File.Delete(fullPath);
    }
}
chnage here also 
 public async Task<Employee?> GetEmployeeByIdAsync(int id)
 {
    var emp=  await _context.employees.FindAsync(id);
     if (emp != null)
     {
         emp.ImagePath = string.IsNullOrEmpty(emp.ImagePath)
             ? GetBaseUrl() + "/uploads/default.jpg"
             : GetBaseUrl() + emp.ImagePath;
     }
     return emp;
 }


next 
 public async Task<Employee> AddEmployeeAsync(Employee employee,IFormFile image) 
 {
     if(image!=null && image.Length > 0)
     {
         employee.ImagePath = SaveImageToUploads(image);
   
         
     }
     else
     {
         employee.ImagePath = "/uploads/default.jpg";
     }
         await _context.employees.AddAsync(employee);
     await _context.SaveChangesAsync();
     employee.ImagePath = GetBaseUrl() + employee.ImagePath;
     return employee;
 }
next change 
 public async Task<Employee?> UpdateEmployeeAsync(Employee employee,IFormFile? image)
 {
     var existing = await _context.employees.FindAsync(employee.Id);
     if (existing == null) return null;

     existing.FirstName = employee.FirstName;
     existing.LastName = employee.LastName;
     existing.Email = employee.Email;
     existing.Age = employee.Age;

     if (image != null && image.Length > 0)
     {
         DeleteImageFile(existing.ImagePath);
         existing.ImagePath = SaveImageToUploads(image);
     }

     await _context.SaveChangesAsync();

     if (!string.IsNullOrEmpty(existing.ImagePath))
         existing.ImagePath = GetBaseUrl() + existing.ImagePath;

     return existing;

 }

final code which i had done changes 
------------------------------------
in emloyeeservice 
---------------------
using Microsoft.EntityFrameworkCore;
using WebApiInAsp.netcoreMvcDemo.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApiInAsp.netcoreMvcDemo
{
    public class EmployeeService : IEmployee
    {
        private readonly EmpContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeService(EmpContext context,IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetBaseUrl()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null) throw new InvalidOperationException("No HttpContext");
            var request = httpContext.Request;
            return $"{request.Scheme}://{request.Host}";
        }
       // FileStream fs;
        public async Task<Employee> AddEmployeeAsync(Employee employee,IFormFile image)
        {
            if(image!=null && image.Length > 0)
            {
                employee.ImagePath = SaveImageToUploads(image);
          
                
            }
            else
            {
                employee.ImagePath = "/uploads/default.jpg";
            }
                await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            employee.ImagePath = GetBaseUrl() + employee.ImagePath;
            return employee;
        }

        public async Task<Employee?> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null) return null;
            DeleteImageFile(employee.ImagePath);
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            employee.ImagePath = null; // optional to avoid exposing deleted image URL
            return employee;

           
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(int pageNumber,int pageSize)
        {
            var employees = await _context.employees.
                Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            string baseUrl = GetBaseUrl();
            foreach(var e in employees)
            {
                e.ImagePath = string.IsNullOrEmpty(e.ImagePath) ?
                    baseUrl + "/uploads/default.jpg" : baseUrl + e.ImagePath;
            }
            return employees;
            
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
           var emp=  await _context.employees.FindAsync(id);
            if (emp != null)
            {
                emp.ImagePath = string.IsNullOrEmpty(emp.ImagePath)
                    ? GetBaseUrl() + "/uploads/default.jpg"
                    : GetBaseUrl() + emp.ImagePath;
            }
            return emp;
        }
        private void DeleteImageFile(string? imagePath) 
        {
            if (string.IsNullOrEmpty(imagePath)||imagePath.Contains("default.jpg"))
                return;

            var fullPath = Path.Combine
                (_env.WebRootPath, imagePath.TrimStart('/').Replace
                ('/', Path.DirectorySeparatorChar));
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        private string SaveImageToUploads(IFormFile image)
        {
            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var uploadPath = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fullPath = Path.Combine(uploadPath, imageName);
            using var stream = new FileStream(fullPath, FileMode.Create);
            image.CopyTo(stream);

            return "/uploads/" + imageName;
        }
        public async Task<Employee?> UpdateEmployeeAsync(Employee employee,IFormFile? image)
        {
            var existing = await _context.employees.FindAsync(employee.Id);
            if (existing == null) return null;

            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Email = employee.Email;
            existing.Age = employee.Age;

            if (image != null && image.Length > 0)
            {
                DeleteImageFile(existing.ImagePath);
                existing.ImagePath = SaveImageToUploads(image);
            }

            await _context.SaveChangesAsync();

            if (!string.IsNullOrEmpty(existing.ImagePath))
                existing.ImagePath = GetBaseUrl() + existing.ImagePath;

            return existing;

        }
    }
}
