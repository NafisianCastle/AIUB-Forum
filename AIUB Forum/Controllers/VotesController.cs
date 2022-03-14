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
    public class VotesController : Controller
    {
        private readonly AIUB_ForumEntities2 _db = new AIUB_ForumEntities2();

        // GET: Votes
        public ActionResult Index()
        {
            var votes = _db.Votes.Include(v => v.Post).Include(v => v.User);
            return View(votes.ToList());
        }

        // GET: Votes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vote = _db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(_db.Posts, "PostId", "Body");
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteId,PostId,UserId,Date")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                _db.Votes.Add(vote);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(_db.Posts, "PostId", "Body", vote.PostId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", vote.UserId);
            return View(vote);
        }

        // GET: Votes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vote = _db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(_db.Posts, "PostId", "Body", vote.PostId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", vote.UserId);
            return View(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoteId,PostId,UserId,Date")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(vote).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(_db.Posts, "PostId", "Body", vote.PostId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", vote.UserId);
            return View(vote);
        }

        // GET: Votes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vote = _db.Votes.Find(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vote = _db.Votes.Find(id);
            _db.Votes.Remove(vote);
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
