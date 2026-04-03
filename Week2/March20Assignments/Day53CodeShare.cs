
  <form asp-action="SetA" method="post">
        <button type="submit" class="btn btn-primary">Set A to 10</button>
    </form>

    <form asp-action="GetA" method="post">
        <button type="submit" class="btn btn-secondary">Get A Value</button>
    </form>

    <p>Value of A: @ViewBag.AValue</p>


In the Home conotorller 

--------------------

 private int a = 0;

 [HttpPost]
 public IActionResult SetA()
 {
     a = 10;
     ViewBag.AValue = "A has been set to 10 ";
     return View("Index");
 }
 [HttpPost]
 public IActionResult GetA()
 {
     ViewBag.AValue = $"A is currently :{a}";
     return View("Index");
 }

go to Models folder add one class LoginViewModel 

   using System.ComponentModel.DataAnnotations;

namespace WebApplication22.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
Add one controlller with the name AccountController which is empty one of mvc type 

using Microsoft.AspNetCore.Mvc;
using StateMgtDemoinAsp.netcore.Models;

namespace StateMgtDemoinAsp.netcore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(1)// set cookie
                };
                Response.Cookies.Append("UserName", model.Username, cookieOptions);
                return RedirectToAction("Welcome");
            }
            return View(model);
        }

    }
}

add view for Login get method it is create with model LoginViewModel 

@model StateMgtDemoinAsp.netcore.Models.LoginViewModel

@{
    ViewData["Title"] = "Login";
}

<h1>Login</h1>

<h4>LoginViewModel</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Login">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="Username" class="control-label"></label>
                <input asp-for="Username" class="form-control" />
                <span asp-validation-for="Username" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Password" class="control-label"></label>
                <input asp-for="Password" class="form-control" />
                <span asp-validation-for="Password" class="text-danger"></span>
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

next add Welcome action methd and logout action methods 
 public IActionResult Welcome()
 {
     if(Request.Cookies.ContainsKey("UserName"))
     {
         string username = Request.Cookies["UserName"];
         ViewBag.UserName = username;
     }
     else
     {
         return RedirectToAction("Login");
     }
   return View();
 }

 [HttpPost]
 public IActionResult Logout()
 {
     Response.Cookies.Delete("UserName");
     return RedirectToAction("Login");
 }

Now add welcome view now here empty page and put my desingin

@{
    ViewData["Title"] = "Welcome";
}

<h1>Welcome</h1>

@if (ViewBag.UserName != null)
{
    <h2>Welcome, @ViewBag.UserName!</h2>
}
<button type="button" class="btn btn-primary ">click me</button>
<form asp-action="Logout" method="post">
    <button type="submit" class="btn btn-danger">Logout</button>
</form>

same codng i want to do using session here session is server side i need to set the session in the midddleware means program.cs file i need to set 
  so same programming using session 

  go to program .cs and write this code 

   // Add session service with a timeout (set to 30 minutes here).
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1); // Session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // Required for GDPR compliance
            });



   app.UseSession();  // Enable session middleware

updated account controler code 
-------------------------------
using Microsoft.AspNetCore.Mvc;
using StateMgtDemoinAsp.netcore.Models;

namespace StateMgtDemoinAsp.netcore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                //var cookieOptions = new CookieOptions
                //{
                //    Expires = DateTime.Now.AddMinutes(1)// set cookie
                //};
                //Response.Cookies.Append("UserName", model.Username, cookieOptions);
                HttpContext.Session.SetString("UserName", model.Username);
                return RedirectToAction("Welcome");
            }
            return View(model);
        }

        public IActionResult Welcome()
        {
            var username = HttpContext.Session.GetString("UserName");
            //if(Request.Cookies.ContainsKey("UserName"))
            //{
            //    string username = Request.Cookies["UserName"];
            //    ViewBag.UserName = username;
            //}
            if(!String.IsNullOrEmpty(username))
            {
                ViewBag.UserName = username;
            }
            else
            { 
                return RedirectToAction("Login");
            }
          return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            //  Response.Cookies.Delete("UserName");
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login");
        }

    }
}

now again try to run the program you will get the same effect over here 

now let us go with temp data demo now which is again server side state management .

Now remember that view bag and view data etc are not doing statemanagement they are for one single request and response 

so make that thing clear 

so for one subsquent request i need tempdata here when i want to send data from one action to another action method and it can be of different controller as well okay ..

tempdata internally use session to store data .

keep is used to send or to save data it wont read so if  want both means i have to use peek

go to home conroller and write like this 

   public IActionResult Index()
 {
     
     return View();
 }
 public IActionResult Index2()
 {
     return View();
 }
 public IActionResult Index3()
 {
     return View();
 }

updated codes verison 1 
  --------------------
    public IActionResult Index()
  {
      TempData["myKey"] = "Data from Index method";
      return View();
  }
  public IActionResult Index2()
  {
      ViewBag.MyKey = TempData["myKey"];
      TempData.Keep("myKey");
      return View();
  }
  public IActionResult Index3()
  {
      ViewBag.Mykey = TempData["myKey"];
      return View();
  }
  
  from 1 to 3 
    ----------
    public IActionResult Index()
{
    TempData["myKey"] = "Data from Index method";
    return View();
}
public IActionResult Index2()
{
    HttpContext.Session.Remove("myKey");
    TempData.Peek("myKey");
    //ViewBag.MyKey = TempData["myKey"];
    //TempData.Keep("myKey");
    return View();
}
public IActionResult Index3()
{
    ViewBag.Mykey = TempData["myKey"];
    
    return View();
}

paste this code in index4.cshtml 
-----------------------------------
public IActionresult 
 
<button onclick="setData()">Set Data</button>
<button onclick="getData()">Get Data</button>
<p id="output"></p>

<script>
    function setData() {
        localStorage.setItem('key', 'This is local storage data');
    }

    function getData() {
        const data = localStorage.getItem('key');
        document.getElementById('output').innerText = data || 'No data found';
    }
</script>

JQuery 
---------
create one folder in Day53 with the name JqueryCodes and open jqueryCodes in vscode and add one html file there 
with the name demo1.html and paste the below code over there 


demo1.html
---------
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<script src="https://code.jquery.com/jquery-3.7.1.min.js">
</script>
<script type="text/javascript" language="Javascript">
    $(document).ready(
        function () {
            $("#newdiv").click(
                function () {
                    alert("you have clicked the div ")
                }

            )
        }

    )
</script>

<body>
    <div id="newdiv">click on this to see a dialogue box </div>
</body>

</html>


demo2.html 
-----------
<p class="myclass">This is a paragraph.</p> 
<p id="myid">This is second paragraph.</p>
<p>This is third paragraph.</p> 

comlete code 
--------------
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<script src="https://code.jquery.com/jquery-3.7.1.min.js">
</script>
<script type="text/javascript" language="Javascript">
    $(document).ready(
        function()
        {
         var pars=$("p");
         for(i=0;i<pars.length;i++)
         {
            alert("Found paragraph:"+pars[i].innerHTML)
         }
        }
    )
</script>
<body>
<p class="myclass">This is a paragraph.</p>
<p id="myid">This is second paragraph.</p>
<p>This is third paragraph.</p>
</body>

</html>
demo3.html
-----------
body code 
----------
<div> 
 <em title="Bold and Brave">This is first paragraph.</em> 
 <p id="myid">This is second paragraph.</p> 
 <div id="divid">
 </div>
 </div> 

  full code:
-------------
  <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<script src="https://code.jquery.com/jquery-3.7.1.min.js">
</script>
<script type="text/javascript" language="Javascript">
    $(document).ready(
        function () {
            var title = $("em").attr("title");
            $("#divid").text(title);
        }

    )
</script>

<body>
    <div>
        <em title="Bold and Brave">This is first paragraph.</em>
        <p id="myid">This is second paragraph.</p>
        <div id="divid">
        </div>
    </div>
</body>

</html>

Demo4.html
----------
body code :
----------
  add two images in your folder only 
  <div> 
        <img id="myimg" src="smileyhover.png"  width="300px" height="300px"
         alt="Sample image" /> 
    </div> 
    
    
  put those images in same folder jquerydemos

  full code 
  ---------
  <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<script src="https://code.jquery.com/jquery-3.7.1.min.js">
</script>
<script type="text/javascript" language="Javascript">
    $(document).ready(
        function () {
            $("div").mouseenter(

                function () {
                    $("#myimg").attr("src", "smileyhover.png")
                }

            );

            $("div").mouseleave(

                function () {
                    $("#myimg").attr("src", "smileynormal.png")
                }
            )

        }

    )
</script>

<body>
    <div>
        <img id="myimg" src="smileyhover.png" width="300px" height="300px" alt="Sample image" />
    </div>
</body>

</html>

Demo5.html
-----------
boby code :
----------
  <button id="move_up">Move Up</button>
    <button id="move_down">Move Down</button>
    <button id="color">Change Color</button>
    <button id="disappear">Disappear/Re-appear</button>
    <div id="change_me">Make Me Do Stuff!</div> 
    
    and in head add this style also 
    
       <style> 
        #change_me {
        position: absolute;
        top: 100px;
        left: 400px;
        font: 24px arial;}
        #move_up #move_down #color #disappear {
        padding: 5px;}
      </style>


    complete code 
    -----------------
    <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        #change_me {
            position: absolute;
            top: 100px;
            left: 400px;
            font: 24px arial;
        }

        #move_up #move_down #color #disappear {
            padding: 5px;
        }
    </style>
</head>
<script src="https://code.jquery.com/jquery-3.7.1.min.js">
</script>
<script type="text/javascript" language="Javascript">
    $(document).ready(
        function () {
            $("#move_up").click(

                function () {
                    $("#change_me").animate({ top: 30 }, 2000)
                }

            );
            $("#move_down").click(

                function () {
                    $("#change_me").animate({ top: 400 }, 2000)
               }
            );

             $("#disappear").click(

                function () {
                    $("#change_me").toggle("slow")
                }
            );

             $("#color").click(

                function () {
                    $("#change_me").css("color","purple")
                }
            );

        }

    )
</script>

<body>
    <button id="move_up">Move Up</button>
    <button id="move_down">Move Down</button>
    <button id="color">Change Color</button>
    <button id="disappear">Disappear/Re-appear</button>
    <div id="change_me">Make Me Do Stuff!</div>
</body>

</html>
