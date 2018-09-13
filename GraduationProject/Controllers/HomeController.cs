using GraduationProject.Models;
using GraduationProject.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index(string query =null)
        {
           
            HomeViewModel VModel = new HomeViewModel();

            var userid = User.Identity.GetUserId();
            VModel.Posts = db.PostTable.Include("User").ToList();
            VModel.Event = db.Event.ToList();
            VModel.EventUserTable = db.EventUserTable.ToList();
            VModel.AboutMeTagsUSerTable = db.AboutMeTagsUserTable.ToList();
            VModel.Workshops = db.Workshops.ToList();
            VModel.WorkshopUserTable = db.WorkshopUserTable.ToList();
            VModel.JobApplicationPost = db.JobApplicationPost.Include("Talented").ToList();
            VModel.TalentedUser = db.TalentedUser.ToList();
            VModel.TalentAcquisition = db.TalentAcquisition.ToList();
            VModel.postTags = db.TagUserTable.ToList();
            VModel.Tags = db.Tags.ToList();

          
            return View(VModel);


        }
        [Authorize]
        public ActionResult LinkDisplay(int id)
        {
            var talent = db.TalentedUser.Single(w => w.Id == id);

            var model = new TalentedUserViewModel
            {
                Talented = db.TalentedUser.Find(id),
                Id = talent.Id

            };

            return View(model);
        }

        [Authorize]
        public ActionResult LinkAboutDisplay(int id)
        {
            TalentedUserViewModel talent = new TalentedUserViewModel();
            talent.TalentedUser = db.TalentedUser.Where(w => w.Id == id).ToList();

            return View(talent);

        }

        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(HomeViewModel model)
        {
            return RedirectToAction("Index", "Home", new {query =model.SearchTerm     });
        }
       
        [Authorize]
        public ActionResult LinkExperience(int id)
        {

            TalentedUserViewModel experience = new TalentedUserViewModel();
            experience.Experience = db.Experience.Where(w => w.TU_Id == id).ToList();
            return View(experience);

        }
        [Authorize]
        public ActionResult LinkEventDisplay(int id)
        {

            TalentedUserViewModel Eve = new TalentedUserViewModel();
            Eve.Event = db.Event.Where(w => w.TU_Id == id).ToList();
            return View(Eve);

        }
        [Authorize]
        public ActionResult LinkWorkshopDisplay(int id)
        {

            TalentedUserViewModel Eve = new TalentedUserViewModel();
            Eve.Workshop = db.Workshops.Where(w => w.TU_Id == id).ToList();
            return View(Eve);

        }

    }
}