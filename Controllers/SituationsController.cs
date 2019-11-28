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
    public class SituationsController : Controller
    {
        private GreyMatterEntities db = new GreyMatterEntities();

        // GET: Situations
        public ActionResult Index()
        {
            return View(db.Situations.ToList());
        }

        // GET: Situations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situation situation = db.Situations.Find(id);
            if (situation == null)
            {
                return HttpNotFound();
            }
            return View(situation);
        }

        // GET: Situations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Situations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DisplayText,CreatorId,PictureAddress,CreatedOnUtc,UpdatedOnUtc,UpVotes,DownVotes")] Situation situation)
        {
            if (ModelState.IsValid)
            {
                db.Situations.Add(situation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(situation);
        }

        // GET: Situations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situation situation = db.Situations.Find(id);
            if (situation == null)
            {
                return HttpNotFound();
            }
            return View(situation);
        }

        // POST: Situations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DisplayText,CreatorId,PictureAddress,CreatedOnUtc,UpdatedOnUtc,UpVotes,DownVotes")] Situation situation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(situation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(situation);
        }

        // GET: Situations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situation situation = db.Situations.Find(id);
            if (situation == null)
            {
                return HttpNotFound();
            }
            return View(situation);
        }

        // POST: Situations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Situation situation = db.Situations.Find(id);
            db.Situations.Remove(situation);
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
