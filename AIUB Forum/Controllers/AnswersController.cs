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
    public class AnswersController : Controller
    {
        private readonly AIUB_ForumEntities2 _db = new AIUB_ForumEntities2();

        // GET: Answers
        public ActionResult Index()
        {
            var answers = _db.Answers.Include(a => a.Post).Include(a => a.User);
            return View(answers.ToList());
        }

        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var answer = _db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: Answers/Create
        public ActionResult Create()
        {
            ViewBag.PostId = new SelectList(_db.Posts, "PostId", "Body");
            ViewBag.AnsUserId = new SelectList(_db.Users, "UserId", "Location");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnsId,Body,CreateDate,ModifyDate,DeleteDate,PostId,Score,AnsUserId")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                _db.Answers.Add(answer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(_db.Posts, "PostId", "Body", answer.PostId);
            ViewBag.AnsUserId = new SelectList(_db.Users, "UserId", "Location", answer.AnsUserId);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var answer = _db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(_db.Posts, "PostId", "Body", answer.PostId);
            ViewBag.AnsUserId = new SelectList(_db.Users, "UserId", "Location", answer.AnsUserId);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnsId,Body,CreateDate,ModifyDate,DeleteDate,PostId,Score,AnsUserId")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(answer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(_db.Posts, "PostId", "Body", answer.PostId);
            ViewBag.AnsUserId = new SelectList(_db.Users, "UserId", "Location", answer.AnsUserId);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var answer = _db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var answer = _db.Answers.Find(id);
            _db.Answers.Remove(answer);
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
