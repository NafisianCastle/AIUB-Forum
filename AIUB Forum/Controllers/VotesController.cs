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
        private readonly AIUB_ForumEntities _db = new AIUB_ForumEntities();

        public ActionResult Index()
        {
            var votes = _db.Votes.Include(v => v.Post).Include(v => v.User);
            return View(votes.ToList());
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteId,PostId,UserId,Date")] Vote vote)
        {
            _db.Votes.Add(vote);
            _db.SaveChanges();
            return new EmptyResult();
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
