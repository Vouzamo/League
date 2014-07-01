using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Core.Models.Classes;
using Core.Data;

namespace Web.Controllers
{
    public class LegController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Leg/
        public async Task<ActionResult> Index()
        {
            var legs = db.Legs.Include(l => l.Fixture);
            return View(await legs.ToListAsync());
        }

        // GET: /Leg/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leg leg = await db.Legs.FindAsync(id);
            if (leg == null)
            {
                return HttpNotFound();
            }
            return View(leg);
        }

        // GET: /Leg/Create
        public ActionResult Create()
        {
            ViewBag.FixtureId = new SelectList(db.Fixtures, "Id", "Id");
            return View();
        }

        // POST: /Leg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,FixtureId,DateTime")] Leg leg)
        {
            if (ModelState.IsValid)
            {
                leg.Id = Guid.NewGuid();
                db.Legs.Add(leg);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FixtureId = new SelectList(db.Fixtures, "Id", "Id", leg.FixtureId);
            return View(leg);
        }

        // GET: /Leg/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leg leg = await db.Legs.FindAsync(id);
            if (leg == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixtureId = new SelectList(db.Fixtures, "Id", "Id", leg.FixtureId);
            return View(leg);
        }

        // POST: /Leg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,FixtureId,DateTime")] Leg leg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leg).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FixtureId = new SelectList(db.Fixtures, "Id", "Id", leg.FixtureId);
            return View(leg);
        }

        // GET: /Leg/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leg leg = await db.Legs.FindAsync(id);
            if (leg == null)
            {
                return HttpNotFound();
            }
            return View(leg);
        }

        // POST: /Leg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Leg leg = await db.Legs.FindAsync(id);
            db.Legs.Remove(leg);
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
