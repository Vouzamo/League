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
    public class SeasonController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Season/
        public async Task<ActionResult> Index()
        {
            var seasons = db.Seasons.Include(s => s.AdministrativeBody);
            return View(await seasons.ToListAsync());
        }

        // GET: /Season/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = await db.Seasons.FindAsync(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // GET: /Season/Create
        public ActionResult Create()
        {
            ViewBag.AdministrativeBodyId = new SelectList(db.AdministrativeBodies, "Id", "Name");
            return View();
        }

        // POST: /Season/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,AdministrativeBodyId,Name,Year")] Season season)
        {
            if (ModelState.IsValid)
            {
                season.Id = Guid.NewGuid();
                db.Seasons.Add(season);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AdministrativeBodyId = new SelectList(db.AdministrativeBodies, "Id", "Name", season.AdministrativeBodyId);
            return View(season);
        }

        // GET: /Season/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = await db.Seasons.FindAsync(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdministrativeBodyId = new SelectList(db.AdministrativeBodies, "Id", "Name", season.AdministrativeBodyId);
            return View(season);
        }

        // POST: /Season/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,AdministrativeBodyId,Name,Year")] Season season)
        {
            if (ModelState.IsValid)
            {
                db.Entry(season).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AdministrativeBodyId = new SelectList(db.AdministrativeBodies, "Id", "Name", season.AdministrativeBodyId);
            return View(season);
        }

        // GET: /Season/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = await db.Seasons.FindAsync(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // POST: /Season/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Season season = await db.Seasons.FindAsync(id);
            db.Seasons.Remove(season);
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
