using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Data;
using Core.Models.Classes;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/AdministrativeBody/
        public async Task<ActionResult> Index()
        {
            return View(await db.AdministrativeBodies.Where(x => x.ApplicationUser.UserName == User.Identity.Name).ToListAsync());
        }

        #region Administrative Body

        // GET: /Admin/CreateAdministrativeBody
        public ActionResult CreateAdministrativeBody()
        {
            return View();
        }

        // POST: /Admin/CreateAdministrativeBody
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAdministrativeBody([Bind(Include = "Name")] AdministrativeBody administrativebody)
        {
            if (ModelState.IsValid)
            {
                administrativebody.Id = Guid.NewGuid();
                administrativebody.ApplicationUserId = User.Identity.GetUserId();

                db.AdministrativeBodies.Add(administrativebody);
                await db.SaveChangesAsync();
                return RedirectToAction("AdministrativeBody", new { id = administrativebody.Id });
            }

            return View(administrativebody);
        }

        // GET: /Admin/AdministrativeBody/5
        public async Task<ActionResult> AdministrativeBody(Guid? id)
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

        // POST: /Admin/AdministrativeBody/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AdministrativeBody([Bind(Include = "Id,ApplicationUserId,Name")] AdministrativeBody administrativebody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrativebody).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("AdministrativeBody", new { id = administrativebody.Id });
            }
            return View(administrativebody);
        }

        #endregion

        #region Season

        // GET: /Admin/CreateSeason
        public ActionResult CreateSeason(Guid id)
        {
            return View(new Season() { AdministrativeBodyId = id });
        }

        // POST: /Admin/CreateSeason
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateSeason([Bind(Include = "AdministrativeBodyId,Name,From,To")] Season season)
        {
            if (ModelState.IsValid)
            {
                season.Id = Guid.NewGuid();

                db.Seasons.Add(season);
                await db.SaveChangesAsync();
                return RedirectToAction("Season", new { id = season.Id });
            }

            return View(season);
        }

        // GET: /Admin/Season/5
        public async Task<ActionResult> Season(Guid? id)
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

        // POST: /Admin/Season/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Season([Bind(Include = "Id,AdministrativeBodyId,Name,From,To")] Season season)
        {
            if (ModelState.IsValid)
            {
                db.Entry(season).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Season", new { id = season.Id });
            }
            return View(season);
        }

        #endregion
    }
}