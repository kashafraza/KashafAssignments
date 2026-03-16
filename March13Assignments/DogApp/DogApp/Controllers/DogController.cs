using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogApp.Models;

namespace DogApp.Controllers
{
    public class DogController : Controller
    {
        private static List<Dog> dogs = new List<Dog>();
        private readonly IWebHostEnvironment _environment;
        public DogController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        // GET: DogController
        public ActionResult Index()
        {
            return View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            return View(dogs.FirstOrDefault(d=>d.ID==id));
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog d,IFormFile imageFile)
        {
          
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var imageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var path = Path.Combine(_environment.WebRootPath, "images", imageName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    d.ImagePath = "/images/" + imageName;
                }

                dogs.Add(d);
                return RedirectToAction("Index");
            }

            return View(d);
        }

        // GET: DogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DogController/Edit/5
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

        // GET: DogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DogController/Delete/5
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
