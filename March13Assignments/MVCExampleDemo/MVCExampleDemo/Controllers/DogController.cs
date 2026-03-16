using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCExampleDemo.Models;
namespace MVCExampleDemo.Controllers
{
    public class DogController : Controller
    {
        static private List<Dog> dogs = new List<Dog>();
        // GET: DogController
        public ActionResult Index()
        {
            return View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            Dog d = new Dog();
            foreach(Dog dog in dogs)
            {
                if(dog.ID==id)
                {
                    d.ID = dog.ID;
                    d.Name = dog.Name;
                    d.Age = dog.Age;
                }
            }
            return View(d);
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog d)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    dogs.Add(d);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Create", d);
                }

            }
            catch
            {
                return View("Create", d);
            }
        }

        // GET: DogController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dog d)
        {
            try
            {
               if(!ModelState.IsValid)
                {
                    return View("Edit", d);
                }
               else
                {
                    foreach(Dog dog in dogs)
                    {
                        if(dog.ID==d.ID)
                        {
                            dog.Name = d.Name;
                            dog.Age = d.Age;
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Edit", d);
            }
        }

        // GET: DogController/Delete/5
        public ActionResult Delete(int id)
        {
            Dog d = new Dog();
            foreach (Dog dog in dogs)
            {
                if (dog.ID == id)
                {
                    d.ID = dog.ID;
                    d.Name = dog.Name;
                    d.Age = dog.Age;
                }
            }
            return View(d);
        }
        [HttpGet]
        public ActionResult DirectDelete(int id)
        {
            foreach(Dog dog in dogs)
            {
                if(dog.ID==id)
                {
                    dogs.Remove(dog);
                    break;
                }
            }
            return RedirectToAction("Index");
                   
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Dog d)
        {
            try
            {
                foreach(Dog dog in dogs)
                {
                    if(dog.ID==d.ID)
                    {
                        dogs.Remove(dog);
                        break;
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
