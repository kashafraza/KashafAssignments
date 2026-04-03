
Partial view :
-----------------
it is a view which acts as part of main view and in layout or in the design where u feel that this desing 
i will be using it again in another controller action method views then make that desing into partial view and
use it everywhere becasue same design putting everywhere will be probem and any modification is there then also u 
have to modify every where that desing so if dynamic desing if u keep it in partial view then one chnage
in partial view code will effect the whole desing so one place change it every where it will effected that is partial view.
here first we will see static partial view which will not take any paramters
inside it and later on partial view which will take some model object than 

@html.partial("name of partial view ",parmaette)

@html.renderpartial("name of partial name)


and always create this partial view in shared folder because some other controller class can also use it as per its requiremnt 

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PartialViewCGDemo.Models;

namespace PartialViewCGDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        Employee emp = new Employee()
        {
           EmpId=101,
           EmpName="ravi",
           Email="ravi@gmail.com",
           Description= "ravi is good working employeeravi" +
            " is good working employeeravi is good working " +
            "employeeravi is good working employeeravi" +
            " is good working employeeravi is good working " +
            "employeeravi is good working employee"
        
        };
        public IActionResult displayemp()
        {

            return View(emp);
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


------------------------
namespace PartialViewCGDemo.Models
{
    public class Employee
    {
        public int EmpId { set; get; }
        public string? EmpName { set; get; }
        public string? Email { set; get; }
        public string? Description { set; get; }
    }
}
--------------
_card 
---------
@model int 

<h2>Hello world -->@Model</h2>


----index 2 view 

@{
    ViewData["Title"] = "Index2";
    int n = 10;
}

<h1>Index2</h1>

@{
    for(int i=0;i<=n;i++)
    {
       @Html.Partial("_Card",@i)
    }
}

-----------display emp view ----
                    @model PartialViewCGDemo.Models.Employee
@{
    ViewData["Title"] = "displayemp";
}

<h1>displayemp</h1>
<div class="row" style="border:solid 3px">

    <div class="col-lg-6">
        <h3>Name:@Model.EmpName</h3>
        <p>ID:@Model.EmpId</p>
        <p>Email:@Model.Email</p>
    </div>
    <div class="col-lg-6">
        <h3>Description</h3>
        <p>@Model.Description</p>
    </div>
</div>
----------empcard----

                    @model PartialViewCGDemo.Models.Employee

<div class="row" style="border:solid 3px">

    <div class="col-lg-6">
        <h3>Name:@Model.EmpName</h3>
        <p>ID:@Model.EmpId</p>
        <p>Email:@Model.Email</p>
    </div>
    <div class="col-lg-6">
        <h3>Description</h3>
        <p>@Model.Description</p>
    </div>
</div>

----------------view now changed to ----

@model PartialViewCGDemo.Models.Employee
@{
    ViewData["Title"] = "displayemp";
}



<h1>displayemp</h1>
@Html.Partial("_EmpCard",@Model)


copy below method in home conroller 
-------------------------------------
       public ActionResult DisplayAllEmp()
       {
           List<Employee> emplist = new List<Employee>()
           {
               new Employee{EmpId=101,EmpName="raghavendra ponde",Email="raghuponde@yahoo.com"
               ,Description="I am freelance trainer etc an etcI am freelance trainer etc an etcI am" +
   " freelance trainer etc an etcI am freelance trainer etc an etcI am" +
" freelance trainer etc an etcI am freelance trainer etc an etc" },

               new Employee{EmpId=102,EmpName="suresh",Email="suresh@yahoo.com"
               ,Description="I am freelance trainer etc an etcI am freelance trainer etc an etcI am" +
   " freelance trainer etc an etcI am freelance trainer etc an etcI am" +
" freelance trainer etc an etcI am freelance trainer etc an etc" },

               new Employee{EmpId=103,EmpName="kiran",Email="kiran@yahoo.com"
               ,Description="I am freelance trainer etc an etcI am freelance trainer etc an etcI am" +
   " freelance trainer etc an etcI am freelance trainer etc an etcI am" +
" freelance trainer etc an etcI am freelance trainer etc an etc" },

               new Employee{EmpId=104,EmpName="mahesh",Email="mahesh@yahoo.com"
               ,Description="I am freelance trainer etc an etcI am freelance trainer etc an etcI am" +
   " freelance trainer etc an etcI am freelance trainer etc an etcI am" +
" freelance trainer etc an etcI am freelance trainer etc an etc" }

           };


           return View(emplist);
       }

     Routing :
----------
Routing is pattern matching system
Routing maps incoming request (from the browser) to a particular resources(controller or action mehod)

domin.com/Home/About




All those path to reach the resource is defined in Routhconfig table path is defined 

so when ever any reauest comes i told first controller will take the request but it is not like that first routeconfig will take it and tell the controller to accept the request 

routeconfig file is parsing the url and if resource is there means that view is there then it gives it othersie 
404 error it will throw

we define route for each action and all the routes are stored in routetable 
each incoming request is mapped to this route table 

and all this route table should be registedred in global.asax file 

two types of routing mechaism is ther e

---->tradational routing (we do it using routeconfig file ) 

---->Attribute routing ( it is avaible from version MVC 5 it is avaiable ) i will do the things by puttng 
  some attibute on top of the action method here i will not use routeconfig file ....
                 

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class Post
    {
        public int Id { set; get; }
        public DateTime DatePublished { set; get; }

        public string Title { set; get; }

        public string Body { set; get; }
    }
}

-----------

        public DbSet<Post> posts { set; get; }

build and run the migration 

Add one foldler with the name Repsoitories in project and add one interface IPost and one class PostRepository like this 
namespace CodeFirstEntityFrameworkDemo.Repositories
{
    public interface IPost
    {

        List<Post> GetPosts();

        Post GetPostByID(int postid);

        void InsertPost(Post post);

        void DeletePost(int postid);

        void UpdatePost(Post post);

        void save();
    }
}

namespace CodeFirstEntityFrameworkDemo.Repositories
{
    public interface IPost
    {

        List<Post> GetPosts();

        Post GetPostByID(int postid);

        void InsertPost(Post post);

        void DeletePost(int postid);

        void UpdatePost(Post post);

        void save();
    }
}

so implementing above interface in class PostRespsotory and implemnted the code 

using CodeFirstEFDEmo.Models;

namespace CodeFirstEFDEmo.Repositories
{
    public class PostRepository : IPost
    {
        private EventContext context;

        public PostRepository(EventContext cnt)
        {
            this.context = cnt;
        }
        public void DeletePost(int postid)
        {
            Post post=context.posts.Find(postid);
            context.posts.Remove(post);
        }

        public Post GetPostByID(int postid)
        {
            return context.posts.Find(postid);
        }

        public List<Post> GetPosts()
        {
            return context.posts.ToList();
        }

        public void InsertPost(Post post)
        {
          context.posts.Add(post);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            context.Entry(post).State =
                Microsoft.
                EntityFrameworkCore.EntityState.Modified;
        }
    }
}


Now u need to register this interface and class in program.cs file 

means injecting dependency

   builder.Services.AddScoped<IPost, PostRepository>();

   Now add one PostController with read and write actions 
   
   using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeFirstEFDEmo.Repositories;
using CodeFirstEFDEmo.Models;
namespace CodeFirstEFDEmo.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postRepository;
        public PostController(IPost postRepository)
        {
            this._postRepository = postRepository;
        }

        // GET: PostController
        public ActionResult Index()
        {
            var posts=_postRepository.GetPosts();
            return View(posts);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
             _postRepository.InsertPost(post);
                _postRepository.save();
            return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}


Final updated code of PostController 
-------------------------------------
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeFirstEFDEmo.Repositories;
using CodeFirstEFDEmo.Models;
using System.ComponentModel.DataAnnotations;
namespace CodeFirstEFDEmo.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postRepository;
        public PostController(IPost postRepository)
        {
            this._postRepository = postRepository;
        }

        // GET: PostController
        public ActionResult Index()
        {
            var posts=_postRepository.GetPosts();
            return View(posts);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
         var post=_postRepository.GetPostByID(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
             _postRepository.InsertPost(post);
                _postRepository.save();
            return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            var post = _postRepository.GetPostByID(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Post post)
        {
          if(id!=post.Id)
            {
                return NotFound();
            }
         else
            {
                _postRepository.UpdatePost(post);
                _postRepository.save();
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            var post = _postRepository.GetPostByID(id);
            if (post == null)
            {
                return NotFound(); 
            }
            return View(post);
        }

        // POST: PostController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
       public ActionResult DeleteConfirmed(int id)
        {
            _postRepository.DeletePost(id);
            _postRepository.save();
            return RedirectToAction(nameof(Index));
        }
    }
}


Views generated graphically so check the desing in your project or the project which i am giving it to u in mail you can 
download that project and see all code and deign for your reference 



                    

