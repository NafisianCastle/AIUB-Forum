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
    public class AnswerVotesController : Controller
    {
        private readonly AIUB_ForumEntities2 _db = new AIUB_ForumEntities2();

        // GET: AnswerVotes
        public ActionResult Index()
        {
            var answerVotes = _db.AnswerVotes.Include(a => a.Answer).Include(a => a.User);
            return View(answerVotes.ToList());
        }

        // GET: AnswerVotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var answerVote = _db.AnswerVotes.Find(id);
            if (answerVote == null)
            {
                return HttpNotFound();
            }
            return View(answerVote);
        }

        // GET: AnswerVotes/Create
        public ActionResult Create()
        {
            ViewBag.AnsId = new SelectList(_db.Answers, "AnsId", "Body");
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location");
            return View();
        }

        // POST: AnswerVotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnsVoteId,AnsId,UserId,Date")] AnswerVote answerVote)
        {
            if (ModelState.IsValid)
            {
                _db.AnswerVotes.Add(answerVote);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnsId = new SelectList(_db.Answers, "AnsId", "Body", answerVote.AnsId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", answerVote.UserId);
            return View(answerVote);
        }

        // GET: AnswerVotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var answerVote = _db.AnswerVotes.Find(id);
            if (answerVote == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnsId = new SelectList(_db.Answers, "AnsId", "Body", answerVote.AnsId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", answerVote.UserId);
            return View(answerVote);
        }

        // POST: AnswerVotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnsVoteId,AnsId,UserId,Date")] AnswerVote answerVote)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(answerVote).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnsId = new SelectList(_db.Answers, "AnsId", "Body", answerVote.AnsId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "Location", answerVote.UserId);
            return View(answerVote);
        }

        // GET: AnswerVotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var answerVote = _db.AnswerVotes.Find(id);
            if (answerVote == null)
            {
                return HttpNotFound();
            }
            return View(answerVote);
        }

        // POST: AnswerVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var answerVote = _db.AnswerVotes.Find(id);
            _db.AnswerVotes.Remove(answerVote);
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
