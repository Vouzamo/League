using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core.Data;

namespace Web.Areas.Admin.Controllers
{
    [Authorize]
    public class AdministrativeBodyController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /AdministrativeBody/
        public async Task<ActionResult> Index()
        {
            return View(await db.AdministrativeBodies.ToListAsync());
        }
	}
}