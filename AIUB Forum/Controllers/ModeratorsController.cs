using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AIUB_Forum.Models.Database;

namespace AIUB_Forum.Controllers
{
    public class ModeratorsController : Controller
    {
        private readonly AIUB_ForumEntities2 _db = new AIUB_ForumEntities2();

        // GET: Moderators
        public ActionResult Index()
        {
            var moderators = _db.Moderators.Include(m => m.User);
            return View(moderators.ToList());
        }

        // GET: Moderators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var moderator = _db.Moderators.Find(id);
            if (moderator == null)
            {
                return HttpNotFound();
            }
            return View(moderator);
        }

        // GET: Moderators/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location");
            return View();
        }

        // POST: Moderators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModeratorId,UserId")] Moderator moderator)
        {
            if (ModelState.IsValid)
            {
                _db.Moderators.Add(moderator);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", moderator.UserId);
            return View(moderator);
        }

        // GET: Moderators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var moderator = _db.Moderators.Find(id);
            if (moderator == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", moderator.UserId);
            return View(moderator);
        }

        // POST: Moderators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModeratorId,UserId")] Moderator moderator)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(moderator).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", moderator.UserId);
            return View(moderator);
        }

        // GET: Moderators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var moderator = _db.Moderators.Find(id);
            if (moderator == null)
            {
                return HttpNotFound();
            }
            return View(moderator);
        }

        // POST: Moderators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var moderator = _db.Moderators.Find(id);
            _db.Moderators.Remove(moderator);
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
