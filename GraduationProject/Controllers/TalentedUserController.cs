using GraduationProject.Models;
using GraduationProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    [Authorize]

    public class TalentedUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TalentedUserController()
        {
            _context = new ApplicationDbContext();

        }

        public JsonResult GetTags(string searchterm)
        {
            var datalist = _context.Tags.ToList();

            if (searchterm != null)
            {
                datalist = _context.Tags.Where(x => x.Name.Contains(searchterm)).ToList();
            }
            var modifieddate = datalist.Select(x => new
            {
                id = x.Id,
                text = x.Name
            });
            return Json(modifieddate, JsonRequestBehavior.AllowGet);

        }
        [Authorize]
        public ActionResult AboutMe()
        {
            return View();
        }
        [Authorize]
        public ActionResult TalentProfile()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AboutMe(TalentedUserAboutmeViewModel talent,FormCollection form)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.TalentedUser.Where(t => t.TalentedId == userId).FirstOrDefault();
            if (user != null)
            {
                return RedirectToAction("EditProfile");

            }

            else
            {
                var talenteduser = new TalentedUser()
                {
                    TalentedId = User.Identity.GetUserId(),
                    TU_FirstName = talent.TalentedUserInfo.TU_FirstName,
                    TU_LastName = talent.TalentedUserInfo.TU_LastName,
                    TU_Email = talent.TalentedUserInfo.TU_Email,
                    TU_DOB = talent.TalentedUserInfo.TU_DOB.Date,
                    TU_School = talent.TalentedUserInfo.TU_School,
                    TU_Degree = talent.TalentedUserInfo.TU_Degree,
                    TU_Language = talent.TalentedUserInfo.TU_Language,
                    TU_ProfiencyLevel = talent.TalentedUserInfo.TU_ProfiencyLevel,
                    TU_Gender = talent.TalentedUserInfo.TU_Gender,
                    TU_Nationality = talent.TalentedUserInfo.TU_Nationality,
                    TU_SelfDescription = talent.TalentedUserInfo.TU_SelfDescription,
                    TU_Skills = talent.TalentedUserInfo.TU_Skills

                };




                _context.TalentedUser.Add(talenteduser);
                _context.SaveChanges();

                string SelectVal = form["SelectVal"];
                string[] FavIds = SelectVal.Split(',');

                AboutMeTagsUSerTable fav = new AboutMeTagsUSerTable();




                for (int i = 0; i < FavIds.Length; i++)
                {
                    var id = int.Parse(FavIds[i]);

                    fav.Tagsid = id;
                    fav.Userid = User.Identity.GetUserId();

                    _context.AboutMeTagsUserTable.Add(fav);
                    _context.SaveChanges();

                }
                return RedirectToAction("TalentProfile");
            }

        }

        [Authorize]
        public ActionResult AddExperiences()
        {


            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddExperiences(TalentedUserAboutmeViewModel talent)
        {
           // var userid = User.Identity.GetUserId();
          //  var tal = _context.TalentedUser.Single(w => w.TalentedId == userid);

            var experience = new Experience()
            {
                TalentedId = User.Identity.GetUserId(),
                Position = talent.TalentedUserExperience.Position,
                Company = talent.TalentedUserExperience.Company,
                Skills = talent.TalentedUserExperience.Skills
            };
            _context.Experience.Add(experience);

            _context.SaveChanges();
            return RedirectToAction("TalentProfile");
        }

        [Authorize]
        public ActionResult DisplayExperience()
        {
            var userId = User.Identity.GetUserId();
            TalentedUserViewModel experience = new TalentedUserViewModel();
            experience.Experience = _context.Experience.Where(w => w.TalentedId == userId).ToList();
            return View(experience);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AvatarUpload(HttpPostedFileBase file, TalentedUserViewModel model)
        {

            if (file != null)

            {



                model.TU_Avatar = new byte[file.ContentLength];
                file.InputStream.Read(model.TU_Avatar, 0, file.ContentLength);


                var UserId = User.Identity.GetUserId();
                var talenteduser = _context.TalentedUser.Single(t => t.TalentedId == UserId);

                talenteduser.TU_Avatar = model.TU_Avatar;
            }
           


            _context.SaveChanges();
            return RedirectToAction("TalentProfile", "TalentedUser");
        }


        [Authorize]
        public ActionResult DispalyAvatar()
        {
            var userId = User.Identity.GetUserId();
            TalentedUserViewModel avatar = new TalentedUserViewModel();
            avatar.TalentedUser = _context.TalentedUser.Include("Talented").Where(t => t.TalentedId == userId).ToList();

            return View(avatar);
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            var userId = User.Identity.GetUserId();
            var talenteduser = _context.TalentedUser.Single(t => t.TalentedId == userId);
            var experience = _context.Experience.Single(e => e.TalentedId == userId);

            var viewmodel = new TalentedUserAboutmeViewModel
            {

                TU_FirstName = talenteduser.TU_FirstName,
                TU_LastName = talenteduser.TU_LastName,
                TU_Nationality = talenteduser.TU_Nationality,
                TU_ProfiencyLevel = talenteduser.TU_ProfiencyLevel,
                TU_Email = talenteduser.TU_Email,
                TU_Degree = talenteduser.TU_Degree,
                TU_Language = talenteduser.TU_Language,
                TU_School = talenteduser.TU_School,
                TU_SelfDescription = talenteduser.TU_SelfDescription,
                TU_Skills = talenteduser.TU_Skills,
                TU_Gender = talenteduser.TU_Gender,
                TU_DOB = talenteduser.TU_DOB.Value.Date,
                Position = experience.Position,
                Company = experience.Company,
                Skills = experience.Skills,
            };
            return View(viewmodel);
        }



        [Authorize]
        [HttpPost]
        public ActionResult UpdateProfile(TalentedUserAboutmeViewModel talent)
        {
            var userId = User.Identity.GetUserId();
            var talenteduser = _context.TalentedUser.Single(t => t.TalentedId == userId);
            var experience = _context.Experience.Single(e => e.TalentedId == userId);


            talenteduser.TU_FirstName = talent.TU_FirstName;
            talenteduser.TU_LastName = talent.TU_LastName;
            talenteduser.TU_Email = talent.TU_Email;
            talenteduser.TU_DOB = talent.TU_DOB.Date;
            talenteduser.TU_School = talent.TU_School;
            talenteduser.TU_Degree = talent.TU_Degree;
            talenteduser.TU_Language = talent.TU_Language;
            talenteduser.TU_ProfiencyLevel = talent.TU_ProfiencyLevel;
            talenteduser.TU_Gender = talent.TU_Gender;
            talenteduser.TU_Nationality = talent.TU_Nationality;
            talenteduser.TU_SelfDescription = talent.TU_SelfDescription;
            talenteduser.TU_Skills = talent.TU_Skills;
            _context.SaveChanges();

            experience.Position = talent.TalentedUserExperience.Position;
            experience.Company = talent.TalentedUserExperience.Company;
            experience.Skills = talent.TalentedUserExperience.Skills;

            _context.SaveChanges();


            return RedirectToAction("DisplayProfile", "TalentedUser");
        }


        [Authorize]
        public ActionResult DisplayProfile()
       { 
          
            return View();
        }

        [Authorize]
        public ActionResult DisplayAboutMe()
        {
            var userId = User.Identity.GetUserId();
            TalentedUserViewModel talent = new TalentedUserViewModel();
            talent.TalentedUser = _context.TalentedUser.Where(w => w.TalentedId == userId ).ToList();
           talent.AboutMeTagsUserTable = _context.AboutMeTagsUserTable.ToList();
            talent.Tags = _context.Tags.ToList();
            talent.User=_context.Users.ToList();

            return View(talent);
        }
        [Authorize]
        public ActionResult AddWorkshop()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddWorkshop(WorkshopViewModel Workshop,FormCollection form)
        {

           // var userid = User.Identity.GetUserId();
           // var tal = _context.TalentedUser.Single(w => w.TalentedId == userid);

            var viewmodel = new Workshops
            {

                TalentedId = User.Identity.GetUserId(),

                workshop_Name = Workshop.workshop_Name,
                workshop_Date = Workshop.workshop_Date.Date,
                workshop_Fees = Workshop.workshop_Fees,
                workshop_Location = Workshop.workshop_Location,
                workshop_Description = Workshop.workshop_Description,
                workshop_Sessions = Workshop.workshop_Sessions,
                DateTime = DateTime.Now
            };
            _context.Workshops.Add(viewmodel);
            _context.SaveChanges();

          

            string SelectVal = form["SelectVal"];
            string[] FavIds = SelectVal.Split(',');

            

            WorkshopUserTable fav = new WorkshopUserTable();

            for (int i = 0; i < FavIds.Length; i++)
            {
                var id = int.Parse(FavIds[i]);

                fav.Tagsid = id;
                fav.Userid = User.Identity.GetUserId();
                fav.Workshopid = viewmodel.Id;

                _context.WorkshopUserTable.Add(fav);
                _context.SaveChanges();

            }
            return RedirectToAction("AddWorkshop", "TalentedUser");

        }

        [Authorize]
        public ActionResult DisplayWorkshop()
        {
            var userId = User.Identity.GetUserId();
            WorkshopViewModel work = new WorkshopViewModel();
            work.Workshop = _context.Workshops.Include("Talented").Where(w => w.TalentedId == userId).ToList();
            work.Tags = _context.Tags.ToList();
            work.WorkshopTags = _context.WorkshopUserTable.ToList();
            return View(work);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditWorkshop(int id)
        {
            var userId = User.Identity.GetUserId();
            var work = _context.Workshops.Single(w => w.Id == id && w.TalentedId == userId);

            var viewmodel = new WorkshopViewModel
            {
                Id = work.Id,
                workshop_Name = work.workshop_Name,
                workshop_Date = work.workshop_Date.Date,
                workshop_Description = work.workshop_Description,
                workshop_Fees = work.workshop_Fees,
                workshop_Location = work.workshop_Location,
                workshop_Sessions = work.workshop_Sessions

            };

            return View(viewmodel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateWorkshop(WorkshopViewModel workshop,FormCollection form)
        {
            var userId = User.Identity.GetUserId();
            var work = _context.Workshops.Single(w => w.Id == workshop.Id && w.TalentedId == userId);

            work.workshop_Name = workshop.workshop_Name;
            work.workshop_Location = workshop.workshop_Location;
            work.workshop_Date = workshop.workshop_Date.Date;
            work.workshop_Fees = workshop.workshop_Fees;
            work.workshop_Sessions = workshop.workshop_Sessions;
            work.workshop_Description = workshop.workshop_Description;
            work.DateTime = DateTime.Now;
            _context.SaveChanges();

            string SelectVal = form["SelectVal"];
            string[] FavIds = SelectVal.Split(',');



            WorkshopUserTable fav = new WorkshopUserTable();

            for (int i = 0; i < FavIds.Length; i++)
            {
                var id = int.Parse(FavIds[i]);

                fav.Tagsid = id;
                fav.Userid = User.Identity.GetUserId();
                fav.Workshopid = work.Id;

             
                _context.SaveChanges();

            }
            return RedirectToAction("AddWorkshop", "TalentedUser");
        }

        
        [Authorize]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateEvent(EventViewModel Event,FormCollection form)
        {
         //   var userid = User.Identity.GetUserId();
          //  var tal = _context.TalentedUser.Single(w => w.TalentedId == userid);

            string SelectVal = form["SselectVal"];
            string[] FavIds = SelectVal.Split(',');

            var viewmodel = new Event
            {
                TalentedId = User.Identity.GetUserId(),
                Event_Name = Event.Event_Name,
                Event_Date = Event.Event_Date.Date,
                Event_From = Event.Event_From,
                Event_To = Event.Event_To,
                Event_Location = Event.Event_Location,
                Event_Description = Event.Event_Description,
                DateTime= DateTime.Now


            };
            _context.Event.Add(viewmodel);
            _context.SaveChanges();

            int Eventtid = viewmodel.Id;


            EventUserTable favv = new EventUserTable();




            for (int i = 0; i < FavIds.Length; i++)
            {
                var id = int.Parse(FavIds[i]);

                favv.Tagsid = id;
                favv.Userid = User.Identity.GetUserId();
                favv.Eventid = Eventtid;

                _context.EventUserTable.Add(favv);
                _context.SaveChanges();

            }

            return RedirectToAction("CreateEvent", "TalentedUser");
        }


        [Authorize]
        public ActionResult DisplayEvent()
        {
            var userId = User.Identity.GetUserId();
            EventViewModel eve = new EventViewModel();
            eve.Event = _context.Event.Include("Talented").Where(w => w.TalentedId == userId).ToList();
            eve.EventTags = _context.EventUserTable.ToList();
            eve.Tags = _context.Tags.ToList();



            return View(eve);
        }

        [Authorize]
        public ActionResult EditEvent(int id)
        {
            var userId = User.Identity.GetUserId();

            var eve = _context.Event.Single(t => t.Id == id && t.TalentedId == userId);

            var viewmodel = new EventViewModel
            {
                Id = eve.Id,
                Event_Name = eve.Event_Name,
                Event_Date = eve.Event_Date.Date,
                Event_Location = eve.Event_Location,
                Event_Description = eve.Event_Description,
                Event_From = eve.Event_From,
                Event_To = eve.Event_To,

            };

            return View(viewmodel);

        }
        [Authorize]
        public ActionResult UpdateEvent(EventViewModel Event,FormCollection form)
        {

            
                string SselectVal = form["SselectVal"];
                string[] FavIds = SselectVal.Split(',');
                
                var userId = User.Identity.GetUserId();

            var eve = _context.Event.Single(t => t.Id == Event.Id && t.TalentedId == userId);
            eve.Event_Name = Event.Event_Name;
            eve.Event_Location = Event.Event_Location;
            eve.Event_Date = Event.Event_Date;
            eve.Event_From = Event.Event_From;
            eve.Event_To = Event.Event_To;
            eve.Event_Description = Event.Event_Description;
            eve.DateTime = DateTime.Now;

            _context.SaveChanges();


            int Eventtid = eve.Id;


            EventUserTable fa = new EventUserTable();

            for (int i = 0; i< FavIds.Length; i++)
            {
                var id = int.Parse(FavIds[i]);

                fa.Tagsid= id;
                fa.Userid = User.Identity.GetUserId();
                fa.Eventid = Eventtid;

               _context.SaveChanges();
/////*
            }

            return RedirectToAction("CreateEvent", "TalentedUser");
        }

        public ActionResult AddFeedback()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddFeedback(TalentedUserViewModel feedback)
        {
            var viewmodel = new Feedback
            {
                TalentedId = User.Identity.GetUserId(),
                Message = feedback.Message


            };

            _context.Feedback.Add(viewmodel);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        // GET: TalentedUser
        public ActionResult DisplayPost()
        {
            TalentedUserViewModel VModel = new TalentedUserViewModel();
            var userid = User.Identity.GetUserId();
            VModel.PostTable = _context.PostTable.Include("User").Where(p => p.Userid == userid).ToList();
            VModel.postTags = _context.TagUserTable.ToList();
            VModel.Tags = _context.Tags.ToList();


            return View(VModel);

        }
        [Authorize]
        public ActionResult ApplyForJob()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ApplyForJob(JobFormViewModel jobform, int id)
        {
            var job = _context.JobApplicationPost.Single(j => j.Id == id);

            var viewmodel = new JobForm
            {
                TalentedUserId = User.Identity.GetUserId(),
                JobPostId = job.Id,
                FirstName = jobform.FirstName,
                LastName = jobform.LastName,
                Email = jobform.Email,
                Question1 = jobform.Question1,
                PhoneNumber = jobform.PhoneNumber,
                Question2 = jobform.Question2


            };
            _context.JobForm.Add(viewmodel);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult JoinWorkshop()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult JoinWorkshop(WorkshopFormViewModel workshopviewmodel, int id)
        {

            var work = _context.Workshops.Single(w => w.Id == id);
            var viewmodel = new WorkshopForm
            {
                TalentedUserId = User.Identity.GetUserId(),
                WorkshopId = work.Id,
                FirstName = workshopviewmodel.FirstName,
                LastName = workshopviewmodel.LastName,
                Email = workshopviewmodel.Email,
                Age = workshopviewmodel.Age,
                city = workshopviewmodel.city,
                PhoneNumber = workshopviewmodel.PhoneNumber,
                Question1 = workshopviewmodel.Question1,
                Question2 = workshopviewmodel.Question2

            };
            _context.WorkshopForms.Add(viewmodel);
            _context.SaveChanges();
            return View();
        }
        [Authorize]
       

        public ActionResult Index()
        {
            return View();
        }
       
    }
}   