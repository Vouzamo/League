using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Data;
using Core.Models.Classes;

namespace Web.Controllers
{
    public class BrowseController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Browse
        public async Task<ActionResult> Index()
        {
            return View(await db.AdministrativeBodies.ToListAsync());
        }

        // GET: /Browse/AdministrativeBody/id
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

        // GET: /Browse/Season/id
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

        // GET: /Browse/Division/id
        public async Task<ActionResult> Division(Guid? id)
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

        // GET: /Browse/Fixture/id
        public async Task<ActionResult> Fixture(Guid? id)
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
	}
}