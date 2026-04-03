using CodeFirstEFInAsp.netcoreDemo.Models;
using CodeFirstEFInAsp.netcoreDemo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace CodeFirstEFInAsp.netcoreDemo.Controllers
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
            var posts = _postRepository.GetPosts();
            return View(posts);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            var post = _postRepository.GetPostByID(id);
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
        public ActionResult Edit(int id, Post post)
        {
            if (id != post.Id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _postRepository.DeletePost(id);
            _postRepository.save();
            return RedirectToAction(nameof(Index));
        }
    }
}
