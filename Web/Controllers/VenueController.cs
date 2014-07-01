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
    public class VenueController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Venue/
        public async Task<ActionResult> Index()
        {
            return View(await db.Venues.ToListAsync());
        }

        // GET: /Venue/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = await db.Venues.FindAsync(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // GET: /Venue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Venue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Name")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                venue.Id = Guid.NewGuid();
                db.Venues.Add(venue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(venue);
        }

        // GET: /Venue/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = await db.Venues.FindAsync(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: /Venue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Name")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(venue);
        }

        // GET: /Venue/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = await db.Venues.FindAsync(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: /Venue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Venue venue = await db.Venues.FindAsync(id);
            db.Venues.Remove(venue);
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
