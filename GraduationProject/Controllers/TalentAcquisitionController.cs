using GraduationProject.Models;
using GraduationProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    [Authorize]

    public class TalentAcquisitionController : Controller
    {

        
        private readonly ApplicationDbContext _context;
        public TalentAcquisitionController()
        {
            _context = new ApplicationDbContext();

        }
        [HttpPost]
        [Authorize]
        public ActionResult AvatarUpload(HttpPostedFileBase file, TalentAcquisitionViewModel model)
        {

            if (file != null)

            {



                model.TA_Avatar = new byte[file.ContentLength];
                file.InputStream.Read(model.TA_Avatar, 0, file.ContentLength);
               

            }
            var UserId = User.Identity.GetUserId();
            var talenteduser = _context.TalentAcquisition.Single(t => t.TalentedId == UserId);

            talenteduser.TA_Avatar = model.TA_Avatar;


            _context.SaveChanges();
            return RedirectToAction("DisplayTA", "TalentAcquisition");

        }
        [Authorize]
        public ActionResult TAboutMe()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult TAboutMe(TalentAcquisitionViewModel TA)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.TalentAcquisition.Where(t => t.TalentedId == userId).FirstOrDefault();
            if (user != null)
            {
                return RedirectToAction("EditProfile");

            }

            else
            {
                var talentAcq = new TalentAcquisition
                {
                    TalentedId = User.Identity.GetUserId(),
                    TA_FirstName = TA.TA_FirstName,
                    TA_Company = TA.TA_Company,
                    TA_LastName = TA.TA_LastName,
                    TA_Email = TA.TA_Email,
                    TA_Nationality = TA.TA_Nationality,
                    TA_Searching = TA.TA_Searching,
                    TA_CompanyDescription = TA.TA_CompanyDescription

                };
                _context.TalentAcquisition.Add(talentAcq);
                _context.SaveChanges();

                return View("TalentAcquisition");
            }
        }
        [Authorize]
        public ActionResult EditProfile()
        {
            var userId = User.Identity.GetUserId();
            var talentAcq = _context.TalentAcquisition.Single(t => t.TalentedId == userId);
            var viewmodel = new TalentAcquisitionViewModel
            {
                TA_FirstName = talentAcq.TA_FirstName,
                TA_Company = talentAcq.TA_Company,
                TA_Email = talentAcq.TA_Email,
                TA_LastName = talentAcq.TA_LastName,
                TA_Nationality = talentAcq.TA_Nationality,
                TA_Searching = talentAcq.TA_Searching,
                TA_CompanyDescription = talentAcq.TA_CompanyDescription

            };

            return View(viewmodel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateProfile(TalentAcquisitionViewModel TA)
        {
            var userId = User.Identity.GetUserId();
            var talentAcq = _context.TalentAcquisition.Single(t => t.TalentedId == userId);
            talentAcq.TA_Company = TA.TA_Company;
            talentAcq.TA_Email = TA.TA_Email;
            talentAcq.TA_FirstName = TA.TA_FirstName;
            talentAcq.TA_LastName = TA.TA_LastName;
            talentAcq.TA_Nationality = TA.TA_Nationality;
            talentAcq.TA_Searching = TA.TA_Searching;
            talentAcq.TA_CompanyDescription = TA.TA_CompanyDescription;

            _context.SaveChanges();
            return RedirectToAction("DisplayTA", "TalentAcquisition");
        }

        [Authorize]
        public ActionResult DisplayTA()
        {
            return View();

        }
        [Authorize]
        public ActionResult DisplayTAProfile()
        {
            var userId = User.Identity.GetUserId();
            TalentAcquisitionViewModel tA = new TalentAcquisitionViewModel();
            tA.TalentedAcquisition = _context.TalentAcquisition.Where(t => t.TalentedId == userId).ToList();


            return View(tA);
        }

        [Authorize]
        public ActionResult DispalyAvatar()
        {
            var userId = User.Identity.GetUserId();
            TalentAcquisitionViewModel avatar = new TalentAcquisitionViewModel();
            avatar.TalentedAcquisition = _context.TalentAcquisition.Include("Talented").Where(t => t.TalentedId == userId).ToList();

            return View(avatar);
        }
        [Authorize]
        public ActionResult AddJob()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddJob(TalentAcquisitionViewModel Job)
        {
            var talentAcq = new JobApplicationPost
            {
                TalentedId = User.Identity.GetUserId(),
                JobTitle = Job.JobTitle,
                EmploymentType = Job.EmploymentType,
                JobCategory = Job.JobCategory,
                JobDescription = Job.JobDescription,
                JobLocation = Job.JobLocation,
                JobRequirements = Job.JobRequirements,
                Question = Job.Question,
                Benifits = Job.Benifits,
                DateTime = DateTime.Now
            };
            _context.JobApplicationPost.Add(talentAcq);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult DisplayJob()
        {
            var userId = User.Identity.GetUserId();
            TalentAcquisitionViewModel tA = new TalentAcquisitionViewModel();
            tA.JobApplicationPost= _context.JobApplicationPost.Include(t => t.Talented).Where(w => w.TalentedId == userId).ToList();

            return View(tA);
        }

        [Authorize]
        public ActionResult EditJob(int id)
        {
            var userId = User.Identity.GetUserId();
            var talentAcq = _context.TalentAcquisition.Single(t => t.TalentedId == userId);
            var job = _context.JobApplicationPost.Single(t => t.Id==id &&t.TalentedId == talentAcq.TalentedId);

            var viewmodel = new TalentAcquisitionViewModel
            {
                id=job.Id,
                JobTitle = job.JobTitle,
                EmploymentType = job.EmploymentType,
                JobCategory = job.JobCategory,
                Benifits = job.Benifits,
                JobDescription = job.JobDescription,
                JobLocation = job.JobLocation,
                JobRequirements = job.JobRequirements,
                Question = job.Question

            };

            return View(viewmodel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateJob(TalentAcquisitionViewModel jobvm)
        {

            var userId = User.Identity.GetUserId();
            var talentAcq = _context.TalentAcquisition.Single(t => t.TalentedId == userId);
            var Job = _context.JobApplicationPost.Single(w => w.TalentedId == talentAcq.TalentedId && w.Id==jobvm.id);

            Job.JobCategory = jobvm.JobCategory;
            Job.JobDescription = jobvm.JobDescription;
            Job.JobLocation = jobvm.JobLocation;
            Job.JobRequirements = jobvm.JobRequirements;
            Job.JobTitle = jobvm.JobTitle;
            Job.Question = jobvm.Question;
            Job.DateTime = DateTime.Now;

            _context.SaveChanges();
            return RedirectToAction("AddJob", "TalentAcquisition");
        }

        [Authorize]
        public ActionResult AddFeedback()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddFeedback(TalentAcquisitionViewModel feedback)
        {
            var viewmodel = new Feedback
            {
                TalentedId = User.Identity.GetUserId(),
                Message = feedback.Message


            };

            _context.Feedback.Add(viewmodel);
            _context.SaveChanges();
            return RedirectToAction("TalentAcquisition", "TalentAcquisition");
        }
        [Authorize]
        public ActionResult TalentAcquisition()
        {
            return View();
        }
        // GET: TalentAcquisition
        public ActionResult Index()
        {
            return View();
        }
    }
}