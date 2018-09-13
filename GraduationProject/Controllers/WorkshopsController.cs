using GraduationProject.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    [Authorize]

    public class WorkshopsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Workshops
        public ActionResult Index()
        {
            var workshops = db.Workshops.Include(w => w.Talented);
            return View(workshops.ToList());
        }

        // GET: Workshops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshops workshops = db.Workshops.Find(id);
            if (workshops == null)
            {
                return HttpNotFound();
            }
            return View(workshops);
        }

        // GET: Workshops/Create
       

        

       

        // GET: Workshops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshops workshops = db.Workshops.Find(id);
            if (workshops == null)
            {
                return HttpNotFound();
            }
            return View(workshops);
        }

        // POST: Workshops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workshops workshops = db.Workshops.Find(id);
            db.Workshops.Remove(workshops);
            db.SaveChanges();
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
