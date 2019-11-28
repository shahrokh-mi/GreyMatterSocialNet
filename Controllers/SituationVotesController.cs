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
    public class SituationVotesController : Controller
    {
        private GreyMatterEntities db = new GreyMatterEntities();

        // GET: SituationVotes
        public ActionResult Index()
        {
            return View(db.SituationVotes.ToList());
        }

        // GET: SituationVotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SituationVote situationVote = db.SituationVotes.Find(id);
            if (situationVote == null)
            {
                return HttpNotFound();
            }
            return View(situationVote);
        }

        // GET: SituationVotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SituationVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VoterId,SituationId")] SituationVote situationVote)
        {
            if (ModelState.IsValid)
            {
                db.SituationVotes.Add(situationVote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(situationVote);
        }

        // GET: SituationVotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SituationVote situationVote = db.SituationVotes.Find(id);
            if (situationVote == null)
            {
                return HttpNotFound();
            }
            return View(situationVote);
        }

        // POST: SituationVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VoterId,SituationId")] SituationVote situationVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(situationVote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(situationVote);
        }

        // GET: SituationVotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SituationVote situationVote = db.SituationVotes.Find(id);
            if (situationVote == null)
            {
                return HttpNotFound();
            }
            return View(situationVote);
        }

        // POST: SituationVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SituationVote situationVote = db.SituationVotes.Find(id);
            db.SituationVotes.Remove(situationVote);
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
