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
        private AIUB_ForumEntities2 db = new AIUB_ForumEntities2();

        // GET: Moderators
        public ActionResult Index()
        {
            var moderators = db.Moderators.Include(m => m.User);
            return View(moderators.ToList());
        }

        // GET: Moderators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moderator moderator = db.Moderators.Find(id);
            if (moderator == null)
            {
                return HttpNotFound();
            }
            return View(moderator);
        }

        // GET: Moderators/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Location");
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
                db.Moderators.Add(moderator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "Location", moderator.UserId);
            return View(moderator);
        }

        // GET: Moderators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moderator moderator = db.Moderators.Find(id);
            if (moderator == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Location", moderator.UserId);
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
                db.Entry(moderator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Location", moderator.UserId);
            return View(moderator);
        }

        // GET: Moderators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moderator moderator = db.Moderators.Find(id);
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
            Moderator moderator = db.Moderators.Find(id);
            db.Moderators.Remove(moderator);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
