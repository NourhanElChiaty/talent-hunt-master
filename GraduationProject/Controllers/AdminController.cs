using GraduationProject.Models;
using GraduationProject.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    [Authorize]

    public class AdminController : Controller
    {
        private ApplicationDbContext db;

        public AdminController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            AdminViewModel list = new AdminViewModel();

            list.Tags = db.Tags.ToList();
            list.Users = db.Users.ToList();
            list.Event = db.Event.ToList();
            list.PostTable = db.PostTable.ToList();
            list.Workshops = db.Workshops.ToList();
            list.Feedback = db.Feedback.ToList();

            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Tags tags)
        {
            if (ModelState.IsValid)
            {
                db.Tags.Add(tags);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(tags);
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tags tags = db.Tags.Find(id);
            if (tags == null)
            {
                return HttpNotFound();
            }
            return View(tags);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Tags tags)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tags).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(tags);
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tags tags = db.Tags.Find(id);
            if (tags == null)
            {
                return HttpNotFound();
            }
            return View(tags);
        }
        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tags tags = db.Tags.Find(id);
            db.Tags.Remove(tags);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

     

        public ActionResult Deetd(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Deetd")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Workshops/Delete/5
        public ActionResult Delet(int? id)
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
        [HttpPost, ActionName("Delet")]
        [ValidateAntiForgeryToken]

        public ActionResult DeletConfirmed(int id)
        {
            Workshops workshops = db.Workshops.Find(id);
            db.Workshops.Remove(workshops);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Events/Delete/5
        public ActionResult Dele(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Dele")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleConfirmed(int id)
        {
            Event @event = db.Event.Find(id);
            db.Event.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Feedbacks/Delete/5
        public ActionResult Delte(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delte")]
        [ValidateAntiForgeryToken]
        public ActionResult DelteConfirmed(int id)
        {
            Feedback feedback = db.Feedback.Find(id);
            db.Feedback.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: PostTables/Delete/5
        public ActionResult Delee(int? id)
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
        [HttpPost, ActionName("Delee")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleeConfirmed(int id)
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
