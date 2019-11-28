using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreyMatterSocialNet.Models;

namespace GreyMatterSocialNet.Controllers
{
    public class OutcomesController : Controller
    {
        private GreyMatterEntities db = new GreyMatterEntities();

        // GET: Outcomes
        public async Task<ActionResult> Index()
        {
            return View(await db.Outcomes.ToListAsync());
        }

        // GET: Outcomes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outcome outcome = await db.Outcomes.FindAsync(id);
            if (outcome == null)
            {
                return HttpNotFound();
            }
            return View(outcome);
        }

        // GET: Outcomes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Outcomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OptionId,SituationId,Name,DisplayText,CreatorId,PictureAddress,CreatedOnUtc,UpdatedOnUtc,UpVotes,DownVotes")] Outcome outcome)
        {
            if (ModelState.IsValid)
            {
                db.Outcomes.Add(outcome);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(outcome);
        }

        // GET: Outcomes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outcome outcome = await db.Outcomes.FindAsync(id);
            if (outcome == null)
            {
                return HttpNotFound();
            }
            return View(outcome);
        }

        // POST: Outcomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OptionId,SituationId,Name,DisplayText,CreatorId,PictureAddress,CreatedOnUtc,UpdatedOnUtc,UpVotes,DownVotes")] Outcome outcome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outcome).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(outcome);
        }

        // GET: Outcomes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outcome outcome = await db.Outcomes.FindAsync(id);
            if (outcome == null)
            {
                return HttpNotFound();
            }
            return View(outcome);
        }

        // POST: Outcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Outcome outcome = await db.Outcomes.FindAsync(id);
            db.Outcomes.Remove(outcome);
            await db.SaveChangesAsync();
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
