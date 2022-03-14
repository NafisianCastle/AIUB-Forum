using System;
using System.Data.Entity;
using AIUB_Forum.Models.Database;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AIUB_Forum.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        private readonly AIUB_ForumEntities2 _db = new AIUB_ForumEntities2();
        [Authorize]
        public ActionResult Index()
        {
            var posts = _db.Posts.Include(p => p.User);
            return View(posts.ToList());
        }
        [Authorize]
        public ActionResult Profile(int? id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index");
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {
            var entities = new AIUB_ForumEntities2();
            var data = (from e in entities.Users
                        where e.Password.Equals(user.Password) &&
                              e.Email.Equals(user.Email)
                        select e).FirstOrDefault();
            if (data != null)
            {
                FormsAuthentication.SetAuthCookie("data.UserName", false);
                Session["usertype"] = data.UserType;
                Session["userid"] = data.UserId;
                return RedirectToAction("Index");
            }

            TempData["msg"] = "Invalid Credentials";
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            user.UserType = "User";
            user.CreationDate= DateTime.Today;
            if (!ModelState.IsValid) return View(user);
            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult JobPost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult JobPost(Post post)
        {
            return View();
        }

    }
}