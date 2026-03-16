
put this code in the body of html 
 
<form action="/cgi-bin/test.cgi" name="myForm"  
          onsubmit="return(validate());">
 <table cellspacing="2" cellpadding="2" border="1">
 <tr>
   <td align="right">Name</td>
   <td><input type="text" name="Name" /></td>
 </tr>
 <tr>
   <td align="right">EMail</td>
   <td><input type="text" name="EMail" /></td>
 </tr>
 <tr>
   <td align="right">Zip Code</td>
   <td><input type="text" name="Zip" /></td>
 </tr>
 <tr>
 <td align="right">Country</td>
 <td>
 <select name="Country">
   <option value="-1" selected>[choose yours]</option>
   <option value="1">USA</option>
   <option value="2">UK</option>
   <option value="3">INDIA</option>
 </select>
 </td>
 </tr>
 <tr>
   <td align="right"></td>
   <td><input type="submit" value="Submit" /></td>
 </tr>
 </table> </form>

           full code 
---------------------------
 <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script type="text/javascript">

        function validate() {
            if (document.myForm.Name.value == "") {
                alert("provide your name !");
                document.myForm.Name.focus();
                return false;
            }
            if (document.myForm.EMail.value == "") {
                alert("provie email address ");
                document.myForm.EMail.focus();
                return false;
            }

            if (document.myForm.Zip.value == "" || isNaN(document.myForm.Zip.value) || document.myForm.Zip.value.length != 5) {
                alert("provide zip code in format #####");
                document.myForm.Zip.focus();
                return false;
            }

            if (document.myForm.Country.value == "-1") {
                alert("provide country name");
                return false;
            }
            return true;
        }


    </script>
</head>

<body>
    <form action="/cgi-bin/test.cgi" name="myForm" onsubmit="return(validate());">
        <table cellspacing="2" cellpadding="2" border="1">
            <tr>
                <td align="right">Name</td>
                <td><input type="text" name="Name" required /></td>
            </tr>
            <tr>
                <td align="right">EMail</td>
                <td><input type="email" name="EMail" required /></td>
            </tr>
            <tr>
                <td align="right">Zip Code</td>
                <td><input type="text" name="Zip" required /></td>
            </tr>
            <tr>
                <td align="right">Country</td>
                <td>
                    <select name="Country">
                        <option value="-1" selected>[choose yours]</option>
                        <option value="1">USA</option>
                        <option value="2">UK</option>
                        <option value="3">INDIA</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right"></td>
                <td><input type="submit" value="Submit" /></td>
            </tr>
        </table>
    </form>

</body>

</html>

-----------------------------------------------------------------------------------
 Regular Expression in Javascript :
---------------------------------------------
Till now i have done validations to a form or a form fields using normal procedure like which is nothing but basic validations where we will see that mandatory fields are filled but as per the requirement i want to validate the input which i pass in 
the textbox then i will go regular expressions 


regular expressions are there in .net also and also in javascript 


pan card : five chaarcters ,4 numbers and one again alphabet 

some sites to refer :

https://regexhero.net/  

to test without program 

https://regexr.com/  go through this website throghly instructions

and in google type 

regex in javascript and check some tutorials as well and 
in youtube also u can check it by putting the same 


https://www.w3schools.com/jsref/jsref_obj_regexp.asp

https://www.programiz.com/javascript/regex

in youtube :


https://www.youtube.com/watch?v=nlGF-zh0fsg

 in the body paste this 

 <form>
        <table>
            <tr>
                <td>
                    <input type="text" placeholder="email" id="text" />
                </td>
                <td>
                    <div id="result">
    
                    </div>
                </td>
            </tr>
        </table>
        <br /><br />
        <button onclick="validate()" type="button">Submit</button>
    </form>

-------------------complte code -----
 <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script>
        function validate() {
            var mail = document.getElementById("text").value;
            var regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/
            if (regex.test(mail)) {
                document.getElementById("result").innerHTML = "valid email id ";
                document.getElementById("result").style.color = "green";
            }
            else {
                document.getElementById("result").innerHTML = "Invalid email id ";
                document.getElementById("result").style.color = "red";
            }

        }
    </script>
</head>

<body>
    <form>
        <table>
            <tr>
                <td>
                    <input type="text" placeholder="email" id="text" />
                </td>
                <td>
                    <div id="result">

                    </div>
                </td>
            </tr>
        </table>
        <br /><br />
        <button onclick="validate()" type="button">Submit</button>
    </form>
</body>

</html>
    
-----------------onlyjsdemo1.js-----------------
 function test() {
    console.log("Hello world");
}

function test2(num1, num2) {
    return (num1 + num2);
}


test();
let sum = test2(12, 45);
console.log(sum);
//using arrow functions
const testme = () => console.log("Hello world2");
let sum2 = (n1, n2) => (n1 + n2);
testme();
console.log(sum2(12, 56));

//variable.map(element)=>print(element)

var arr = [10, 20, 30, 40, 50];
arr.map((ele) => console.log(ele));

// example 2 
const numbers = [1, 2, 3, 4, 5];
const squares = numbers.map(value => value * value);
console.log(squares);

const people = [{ id: 1, name: "felpie", country: "USA" },
{ id: 2, name: "mohan", country: "INDIA" },
{ id: 3, name: "jagdish", country: "SRILanka" }
]

const names = people.map(p => p.name);
console.log(names);

// filter function
//array.filter(ele=>(condition))

var filtered = numbers.filter(x => x > 3);
console.log(filtered);

now add one file Arraysinjs.html and in body paste this code 
----------------------------------------------------------
 <p id="demo" style="background:rgb(177, 113, 35);width:90%;height:100px;
                font-size:large;font-weight:900px ;">
    
    </p>

final code(still code will be written)
--------------
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <p id="demo" style="background:rgb(177, 113, 35);width:90%;height:100px;
                    font-size:large;font-weight:900px ;">

    </p>
    <script>
        //difference between var,let and const 
        var kk = "hai";
        kk = "hi"// can reassign
        {
            var kk = "hello";
        }
        console.log(kk);

        let kk1 = "hai";
        kk1 = "hi"// can reassign
        {
            let kk1 = "hello"
        }
        console.log(kk1);

        const kk2 = "hai";
        // kk2 = "hi";// u cannot assign here const value in run time it will give error 
        console.log(kk2);

        let cars = ["BMW", "Hyndai", "TATA", "Skoda"];

        document.getElementById("demo").innerHTML = cars;

        // first car 

        let firstcar = cars[0];

        document.getElementById("demo").innerHTML = firstcar;

        //no elements in array

        let length = cars.length;

        document.getElementById("demo").innerHTML = length;

        // last car

        let lastcar = cars[cars.length - 1]

        document.getElementById("demo").innerHTML = lastcar;

        //loop over the array and put it i p tag 

        var str = "";
        for (var i = 0; i < cars.length; i++) {
            str = str + (i + 1) + ":" + cars[i] + "<br/>";
        }
        document.getElementById("demo").innerHTML = str;

        // using for each loop 

        cars.forEach((item, index, array) => { console.log(index + 1) + "----->" + item });

        // removing last car 

        let lastcar1 = cars.pop();

        document.getElementById("demo").innerHTML = lastcar1;

        // adding at the last 

        let lastcar2 = cars.push("AUDI");

        document.getElementById("demo").innerHTML = cars;

        //remoing first car

        let firstcar1 = cars.shift();
        document.getElementById("demo").innerHTML = firstcar1;

        //adding at the begining 
        let newfirstcar = cars.unshift("TOYATO");
        document.getElementById("demo").innerHTML = cars;

        let bikes = ["Gixxer", "Yamaha", "Apache"];

        let vahicles = cars.concat(bikes);

        document.getElementById("demo").innerHTML = vahicles;

        // printing using map function in js

        // Use map to create an HTML list
        document.getElementById("demo").innerHTML = cars.map(car => `<li>${car}</li>`).join('');

        let num1 = [2, 3, 4, 5, 6];
        let num2 = num1.map(x => x * 2);
        document.getElementById("demo").innerHTML = num2;
        //or
        function multiply(value) {
            return value * 3;
        }

        let num3 = num1.map(multiply);
        document.getElementById("demo").innerHTML = num3;

        let num4 = num1.filter(x => x > 4);
        document.getElementById("demo").innerHTML = num4;

        //or

        function comp(value) {
            return value > 4;
        }

        let num5 = num1.filter(comp);

        document.getElementById("demo").innerHTML = num5;

        //reduce will reduce the array to single value 

        function sum(total, value) {
            return total + value;
        }

        let num6 = num1.reduce(sum);
        document.getElementById("demo").innerHTML = num6;
        //or

        let num7 = num1.reduce((total, value) => total + value);

        document.getElementById("demo").innerHTML = num7;

    </script>
</body>

</html>


---- go to drive and download one  folder with name DOMDemo in drive of capgminenin


app.js code 
----------------
 document.addEventListener('DOMContentLoaded', function () {

    // delete movie
    const list = document.querySelector('#movie-list ul');
    const forms = document.forms;

    list.addEventListener('click', (e) => {

        if (e.target.className == "delete") {
            const li = e.target.parentElement;
            li.parentNode.removeChild(li);

        }


    })

    // add movie 

    const addform = forms['add-movie'];
    addform.addEventListener('submit', function (e) {

        e.preventDefault();


        //creating elements

        const value = addform.querySelector('input[type="text"]').value;
        const li = document.createElement('li');
        const moviename = document.createElement('span');
        const deletebtn = document.createElement('span');


        //add text content 

        moviename.textContent = value;
        deletebtn.textContent = 'delete';

        // add classes 
        moviename.classList.add('name');
        deletebtn.classList.add('delete');


        // append to DOM

        li.appendChild(moviename);
        li.appendChild(deletebtn);
        list.appendChild(li);

    })





})

  BOOTSTRAP 
 ------------
 Bootstrap is a free front-end framework for faster and easier web development 
Bootstrap includes HTML and CSS based design templates for typography, forms, buttons, tables, navigation, modals, image 
carousels and many other, as well as optional JavaScript plugins
Bootstrap also gives you the ability to easily create responsive designs

go to getbootstrap.com right side corner go for 5.0.3 version of bootstrap select and  left menu third one download is there 
and first downlod u click unzip the folder 
and finally open the folder in vscode 

add one file index.html in the downloaded fodler having css and js folder 
and code is below 


For designing first learn bootstrap from this link 

https://www.w3schools.com/bootstrap5/


and after learning go to this link 

https://getbootstrap.com/docs/5.0/getting-started/introduction/

and in this in search type what u want like forms ,dropdowns etc 

some code will come try to analize it and replace that code with  your desing code which u need it 


bootswatch.com is another site for taking code into desing 


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>

<body>
    <div id="row1" class="row">
        <div class="col-lg-6 col-md-6 col-sm-6" style="background-color: yellow;">
            <span>row1 col1 </span>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-6" style="background-color:pink">
            <span>row1 col2 </span>
        </div>

    </div>

    <div id="row2" class="row">
        <div class="col-lg-2 col-md-8 col-sm-6" style="background-color: aqua;">
            <span>row2 col1</span>
        </div>
        <div class="col-lg-8 col-md-3 col-sm-1" style="background-color: fuchsia;">
            <span>row2 col2</span>
        </div>
        <div class="col-lg-2 col-md-1 col-sm-5" style="background-color: palegreen;">
            <span>row2 col3 </span>
        </div>

    </div>

    <div id="row3" class="row">
        <div class="col-lg-6 col-md-6 col-sm-6" style="background-color: burlywood;">
            <span>row3 col1</span>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-6" style="background-color: rgb(154, 135, 222);">
            <span>row3 col2</span>
            <div id="row4" class="row">
                <div class="col-lg-8 col-md-8 col-sm-8" style="background-color: navajowhite;">
                    row4 col1
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4" style="background-color: rgb(200, 21, 30);">
                    row4 col2
                </div>
            </div>

        </div>

    </div>
</body>

</html>


 demo2.html
-----------------
 <!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=`, initial-scale=1.0">
    <title>Document</title>
    <link href="css2/bootstrap.min.css" rel="stylesheet" />
    <link href="css2/bootstrap.css" rel="stylesheet" />
</head>

<body>
    <nav class="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">Navbar</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor01"
                aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarColor01">
                <ul class="navbar-nav me-auto">
                    <li class="nav-item">
                        <a class="nav-link active" href="#">Home
                            <span class="visually-hidden">(current)</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Features</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Pricing</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">About</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#" role="button"
                            aria-haspopup="true" aria-expanded="false">Dropdown</a>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="#">Action</a>
                            <a class="dropdown-item" href="#">Another action</a>
                            <a class="dropdown-item" href="#">Something else here</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">Separated link</a>
                        </div>
                    </li>
                </ul>
                <form class="d-flex">
                    <input class="form-control me-sm-2" type="search" placeholder="Search">
                    <button class="btn btn-secondary my-2 my-sm-0" type="submit">Search</button>
                </form>
            </div>
        </div>
    </nav>

    <div id="row1" class="row">
        <div class="col-lg-3">
            <div class="accordion" id="accordionExample">
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingOne">
                        <button class="accordion-button" type="button" data-bs-toggle="collapse"
                            data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            Accordion Item #1
                        </button>
                    </h2>
                    <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne"
                        data-bs-parent="#accordionExample">
                        <div class="accordion-body">
                            <strong>This is the first item's accordion body.</strong> It is shown by default, until the
                            collapse
                            plugin adds the appropriate classes that we use to style each element. These classes control
                            the overall
                            appearance, as well as the showing and hiding via CSS transitions. You can modify any of
                            this with
                            custom CSS or overriding our default variables. It's also worth noting that just about any
                            HTML can go
                            within the <code>.accordion-body</code>, though the transition does limit overflow.
                        </div>
                    </div>
                </div>
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingTwo">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                            data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                            Accordion Item #2
                        </button>
                    </h2>
                    <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo"
                        data-bs-parent="#accordionExample">
                        <div class="accordion-body">
                            <strong>This is the second item's accordion body.</strong> It is hidden by default, until
                            the collapse
                            plugin adds the appropriate classes that we use to style each element. These classes control
                            the overall
                            appearance, as well as the showing and hiding via CSS transitions. You can modify any of
                            this with
                            custom CSS or overriding our default variables. It's also worth noting that just about any
                            HTML can go
                            within the <code>.accordion-body</code>, though the transition does limit overflow.
                        </div>
                    </div>
                </div>
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingThree">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                            data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                            Accordion Item #3
                        </button>
                    </h2>
                    <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree"
                        data-bs-parent="#accordionExample">
                        <div class="accordion-body">
                            <strong>This is the third item's accordion body.</strong> It is hidden by default, until the
                            collapse
                            plugin adds the appropriate classes that we use to style each element. These classes control
                            the overall
                            appearance, as well as the showing and hiding via CSS transitions. You can modify any of
                            this with
                            custom CSS or overriding our default variables. It's also worth noting that just about any
                            HTML can go
                            within the <code>.accordion-body</code>, though the transition does limit overflow.
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="col-lg-6">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">Type</th>
                        <th scope="col">Column heading</th>
                        <th scope="col">Column heading</th>
                        <th scope="col">Column heading</th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="table-active">
                        <th scope="row">Active</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                    <tr>
                        <th scope="row">Default</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                    <tr class="table-primary">
                        <th scope="row">Primary</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                    <tr class="table-secondary">
                        <th scope="row">Secondary</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                    <tr class="table-success">
                        <th scope="row">Success</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                    <tr class="table-danger">
                        <th scope="row">Danger</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                    <tr class="table-warning">
                        <th scope="row">Warning</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                    <tr class="table-info">
                        <th scope="row">Info</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                    <tr class="table-light">
                        <th scope="row">Light</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                    <tr class="table-dark">
                        <th scope="row">Dark</th>
                        <td>Column content</td>
                        <td>Column content</td>
                        <td>Column content</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="col-lg-3">
            <button type="button" class="btn btn-primary">Primary</button>
            <button type="button" class="btn btn-secondary">Secondary</button>
            <button type="button" class="btn btn-success">Success</button>
            <button type="button" class="btn btn-info">Info</button>
            <button type="button" class="btn btn-warning">Warning</button>
            <button type="button" class="btn btn-danger">Danger</button>
            <button type="button" class="btn btn-light">Light</button>
            <button type="button" class="btn btn-dark">Dark</button>
            <button type="button" class="btn btn-link">Link</button>
        </div>
    </div>

    <hr />

</body>

</html>
