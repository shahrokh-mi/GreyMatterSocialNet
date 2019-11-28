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
    public class OptionVotesController : Controller
    {
        private GreyMatterEntities db = new GreyMatterEntities();

        // GET: OptionVotes
        public ActionResult Index()
        {
            return View(db.OptionVotes.ToList());
        }

        // GET: OptionVotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionVote optionVote = db.OptionVotes.Find(id);
            if (optionVote == null)
            {
                return HttpNotFound();
            }
            return View(optionVote);
        }

        // GET: OptionVotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OptionVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VoterId,OptionId")] OptionVote optionVote)
        {
            if (ModelState.IsValid)
            {
                db.OptionVotes.Add(optionVote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(optionVote);
        }

        // GET: OptionVotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionVote optionVote = db.OptionVotes.Find(id);
            if (optionVote == null)
            {
                return HttpNotFound();
            }
            return View(optionVote);
        }

        // POST: OptionVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VoterId,OptionId")] OptionVote optionVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optionVote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(optionVote);
        }

        // GET: OptionVotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionVote optionVote = db.OptionVotes.Find(id);
            if (optionVote == null)
            {
                return HttpNotFound();
            }
            return View(optionVote);
        }

        // POST: OptionVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionVote optionVote = db.OptionVotes.Find(id);
            db.OptionVotes.Remove(optionVote);
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
