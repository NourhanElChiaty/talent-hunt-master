using GraduationProject.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    [Authorize]

    public class PostTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PostTables
        public ActionResult Index()
        {
            var postTable = db.PostTable.Include(p => p.User);
            return View(postTable.ToList());
        }

        // GET: PostTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostTable postTable = db.PostTable.Find(id);
            if (postTable == null)
            {
                return HttpNotFound();
            }
            return View(postTable);
        }

     
        // GET: PostTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostTable postTable = db.PostTable.Find(id);
            if (postTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Userid = new SelectList(db.Users, "Id", "Name", postTable.Userid);
            return View(postTable);
        }

        // POST: PostTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Imagepath,Description,DateTime,Userid")] PostTable postTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Userid = new SelectList(db.Users, "Id", "Name", postTable.Userid);
            return View(postTable);
        }

        // GET: PostTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostTable postTable = db.PostTable.Find(id);
            if (postTable == null)
            {
                return HttpNotFound();
            }
            return View(postTable);
        }

        // POST: PostTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostTable postTable = db.PostTable.Find(id);
            db.PostTable.Remove(postTable);
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
