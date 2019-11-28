using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreyMatterSocialNet.Models;

namespace GreyMatterSocialNet.Controllers
{
    public class OutcomeVotesController : Controller
    {
        private GreyMatterEntities db = new GreyMatterEntities();

        // GET: OutcomeVotes
        public ActionResult Index()
        {
            return View(db.OutcomeVotes.ToList());
        }

        // GET: OutcomeVotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutcomeVote outcomeVote = db.OutcomeVotes.Find(id);
            if (outcomeVote == null)
            {
                return HttpNotFound();
            }
            return View(outcomeVote);
        }

        // GET: OutcomeVotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OutcomeVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VoterId,OutcomeId")] OutcomeVote outcomeVote)
        {
            if (ModelState.IsValid)
            {
                db.OutcomeVotes.Add(outcomeVote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(outcomeVote);
        }

        // GET: OutcomeVotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutcomeVote outcomeVote = db.OutcomeVotes.Find(id);
            if (outcomeVote == null)
            {
                return HttpNotFound();
            }
            return View(outcomeVote);
        }

        // POST: OutcomeVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VoterId,OutcomeId")] OutcomeVote outcomeVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outcomeVote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(outcomeVote);
        }

        // GET: OutcomeVotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutcomeVote outcomeVote = db.OutcomeVotes.Find(id);
            if (outcomeVote == null)
            {
                return HttpNotFound();
            }
            return View(outcomeVote);
        }

        // POST: OutcomeVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OutcomeVote outcomeVote = db.OutcomeVotes.Find(id);
            db.OutcomeVotes.Remove(outcomeVote);
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
