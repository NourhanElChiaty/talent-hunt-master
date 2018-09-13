using GraduationProject.Models;
using GraduationProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    [Authorize]
    public class PostController : Controller
    { 
        private ApplicationDbContext db;
        public PostController()
        {
            db = new ApplicationDbContext();
        }

        public JsonResult GetTags(string searchterm)
        {
            var datalist = db.Tags.ToList();

            if (searchterm != null)
            {
                datalist = db.Tags.Where(x => x.Name.Contains(searchterm)).ToList();
            }
            var modifieddate = datalist.Select(x => new
            {
                id = x.Id,
                text = x.Name
            });
            return Json(modifieddate, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        // GET: Post
        //    [Authorize(Roles = "Talent,TalentAcquistion")]

        public ActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post(HttpPostedFileBase file, PoostViewModel model,FormCollection form)
        {

            if (ModelState.IsValid)
            {
                string SelectVal = form["SelectVal"];
                string[] FavIds = SelectVal.Split(',');


                if (file != null)

                {
                    model.Imagepath = new byte[file.ContentLength];
                    file.InputStream.Read(model.Imagepath, 0, file.ContentLength);

                }

                var objectt = new PostTable
                {
                    Imagepath = model.Imagepath,
                    Title = model.Title,
                    Description = model.Description,
                    Userid = User.Identity.GetUserId(),
                    DateTime = DateTime.Now,
                };

                db.PostTable.Add(objectt);
                db.SaveChanges();

                int Postid = objectt.Id;


                TagUserTable fav = new TagUserTable();




                for (int i = 0; i < FavIds.Length; i++)
                {
                    var id = int.Parse(FavIds[i]);

                    fav.Tagsid = id;
                    fav.Userid = User.Identity.GetUserId();
                    fav.postid = Postid;
                    
                    db.TagUserTable.Add(fav);
                    db.SaveChanges();

                }


            }
            else
            {
                return View("Post","Post");
            }


            return RedirectToAction("Index", "Post");
        }

        public ActionResult Index()
        {
            PoostViewModel VModel = new PoostViewModel();
            var userid = User.Identity.GetUserId();
            VModel.Posts =  db.PostTable.Include("User").Where(p=>p.Userid==userid).ToList();
             VModel.postTags = db.TagUserTable.ToList();
            VModel.Tags = db.Tags.ToList();


            return View(VModel);

        }
        public ActionResult Edit (int id)
        {
           

            var userid = User.Identity.GetUserId();
            var post = db.PostTable.Single(g => g.Id == id && g.Userid == userid);
            var postView = new PoostViewModel
            {
                id = post.Id,
                Title=post.Title,
                Description= post.Description,
                Imagepath=post.Imagepath,
                DateTime=DateTime.Now,
            };

            return View("Post", postView);
        }
        [HttpPost]
        public ActionResult Update(HttpPostedFileBase file, PoostViewModel model, FormCollection form)
        {
          
            if (ModelState.IsValid)
            {
               

                if (file != null)

                {
                    model.Imagepath = new byte[file.ContentLength];
                    file.InputStream.Read(model.Imagepath, 0, file.ContentLength);

                }
                var userid = User.Identity.GetUserId();
                var objectt = db.PostTable.Single(g => g.Id == model.id && g.Userid == userid);

                objectt.Title = model.Title;
                objectt.Description = model.Description;
                objectt.Imagepath = model.Imagepath;
                objectt.DateTime = DateTime.Now;

                db.SaveChanges();



             

                string SelectVal = form["SelectVal"];
                string[] FavIds = SelectVal.Split(',');

               

                TagUserTable fav = new TagUserTable();

                for (int i = 0; i < FavIds.Length; i++)
                {
                    var id = int.Parse(FavIds[i]);

                    fav.Tagsid = id;
                    fav.Userid = User.Identity.GetUserId();
                    fav.postid = objectt.Id;

                    db.SaveChanges();

                }


            }
            else
            {
                return View("Post","Post");
            }


            return RedirectToAction("Index", "Post");
        }

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