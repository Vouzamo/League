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
    public class AdministrativeBodyController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /AdministrativeBody/
        public async Task<ActionResult> Index()
        {
            return View(await db.AdministrativeBodies.ToListAsync());
        }

        // GET: /AdministrativeBody/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministrativeBody administrativebody = await db.AdministrativeBodies.FindAsync(id);
            if (administrativebody == null)
            {
                return HttpNotFound();
            }
            return View(administrativebody);
        }

        // GET: /AdministrativeBody/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AdministrativeBody/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Name")] AdministrativeBody administrativebody)
        {
            if (ModelState.IsValid)
            {
                administrativebody.Id = Guid.NewGuid();
                db.AdministrativeBodies.Add(administrativebody);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(administrativebody);
        }

        // GET: /AdministrativeBody/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministrativeBody administrativebody = await db.AdministrativeBodies.FindAsync(id);
            if (administrativebody == null)
            {
                return HttpNotFound();
            }
            return View(administrativebody);
        }

        // POST: /AdministrativeBody/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Name")] AdministrativeBody administrativebody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrativebody).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(administrativebody);
        }

        // GET: /AdministrativeBody/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministrativeBody administrativebody = await db.AdministrativeBodies.FindAsync(id);
            if (administrativebody == null)
            {
                return HttpNotFound();
            }
            return View(administrativebody);
        }

        // POST: /AdministrativeBody/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            AdministrativeBody administrativebody = await db.AdministrativeBodies.FindAsync(id);
            db.AdministrativeBodies.Remove(administrativebody);
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
