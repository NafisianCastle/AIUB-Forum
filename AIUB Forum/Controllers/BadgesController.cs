using AIUB_Forum.Auth;
using AIUB_Forum.Models.Database;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AIUB_Forum.Controllers
{
    [AdminAccess]
    public class BadgesController : Controller
    {
        private readonly AIUB_ForumEntities _db = new AIUB_ForumEntities();

        public ActionResult Index()
        {
            var badges = _db.Badges.Include(b => b.User);
            return View(badges.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var badge = _db.Badges.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Badge badge)
        {
            if (ModelState.IsValid)
            {
                _db.Badges.Add(badge);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", badge.UserId);
            return new EmptyResult();
        }
        
       
        public ActionResult Edit(int? id)
        {
            return new EmptyResult();
        }


        // GET: Badges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var badge = _db.Badges.Find(id);
            if (badge == null)
            {
                return HttpNotFound();
            }
            return View(badge);
        }

        // POST: Badges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var badge = _db.Badges.Find(id);
            if (badge != null) _db.Badges.Remove(badge);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
