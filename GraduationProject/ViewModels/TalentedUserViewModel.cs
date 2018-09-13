using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.ViewModels
{
    public class TalentedUserViewModel
    {
        public IEnumerable<Event> Event { get; set; }
        public IEnumerable<Workshops> Workshop { get; set; }
        public IEnumerable<TalentedUser> TalentedUser { get; set; }
        public IEnumerable<Experience> Experience { get; set; }
        public IEnumerable<PostTable> PostTable { get; set; }
        public IEnumerable<Tags> Tags { get; set; }
        public IEnumerable<ApplicationUser> User { get; set; }
        public IEnumerable<TagUserTable> postTags { get; set; }
        public IEnumerable<AboutMeTagsUSerTable> AboutMeTagsUserTable { get;
            set;
        }

        public TalentedUser Talented { get; set; }  
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string TU_FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string TU_LastName { get; set; }

        [Display(Name = "Email")]
        public string TU_Email { get; set; }

        [Display(Name = "School/University")]
        public string TU_School { get; set; }

        [Display(Name = "Date OF Birth")]
        public DateTime TU_DOB { get; set; }

        [Display(Name = "Profiency Level")]
        public string TU_ProfiencyLevel { get; set; }

        [Display(Name = "Degree")]
        public string TU_Degree { get; set; }

        [Display(Name = "Gender")]
        public string TU_Gender { get; set; }

        [Display(Name = "Language")]
        public string TU_Language { get; set; }

        [Display(Name = "Nationality")]
        public string TU_Nationality { get; set; }

        [Display(Name = "Self Description")]
        public string TU_SelfDescription { get; set; }

        [Display(Name = "Skills")]
        public string TU_Skills { get; set; }

        public Byte[] TU_Avatar { get; set; }




        public int Feedback_Id { get; set; }

        [Required]
        public string Message { get; set; }

    }
}