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
    public class DivisionController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Division/
        public async Task<ActionResult> Index()
        {
            var divisions = db.Divisions.Include(d => d.Season);
            return View(await divisions.ToListAsync());
        }

        // GET: /Division/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = await db.Divisions.FindAsync(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // GET: /Division/Create
        public ActionResult Create()
        {
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "Name");
            return View();
        }

        // POST: /Division/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,SeasonId,Name,Sport,CompetitionFormat,ParticipationType")] Division division)
        {
            if (ModelState.IsValid)
            {
                division.Id = Guid.NewGuid();
                db.Divisions.Add(division);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "Name", division.SeasonId);
            return View(division);
        }

        // GET: /Division/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = await db.Divisions.FindAsync(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "Name", division.SeasonId);
            return View(division);
        }

        // POST: /Division/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,SeasonId,Name,Sport,CompetitionFormat,ParticipationType")] Division division)
        {
            if (ModelState.IsValid)
            {
                db.Entry(division).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SeasonId = new SelectList(db.Seasons, "Id", "Name", division.SeasonId);
            return View(division);
        }

        // GET: /Division/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = await db.Divisions.FindAsync(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: /Division/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Division division = await db.Divisions.FindAsync(id);
            db.Divisions.Remove(division);
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
