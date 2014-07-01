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
    public class FixtureController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Fixture/
        public async Task<ActionResult> Index()
        {
            var fixtures = db.Fixtures.Include(f => f.Division);
            return View(await fixtures.ToListAsync());
        }

        // GET: /Fixture/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = await db.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // GET: /Fixture/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "Name");
            return View();
        }

        // POST: /Fixture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,DivisionId")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                fixture.Id = Guid.NewGuid();
                db.Fixtures.Add(fixture);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "Name", fixture.DivisionId);
            return View(fixture);
        }

        // GET: /Fixture/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = await db.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "Name", fixture.DivisionId);
            return View(fixture);
        }

        // POST: /Fixture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,DivisionId")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixture).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "Name", fixture.DivisionId);
            return View(fixture);
        }

        // GET: /Fixture/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixture fixture = await db.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return HttpNotFound();
            }
            return View(fixture);
        }

        // POST: /Fixture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Fixture fixture = await db.Fixtures.FindAsync(id);
            db.Fixtures.Remove(fixture);
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
