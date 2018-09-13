using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.ViewModels
{
    public class TalentedUserAboutmeViewModel
    {

        public TalentedUserViewModel TalentedUserInfo { get; set; }
        public ExperienceViewModel TalentedUserExperience { get; set; }
        public string[] SelectVal { get; set; }

        [Required]
        public string TalentedId { get; set; }
        public int Id { get; set; }


        public string Position { get; set; }
        public string Company { get; set; }
        public string Skills { get; set; }

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
        public List<TalentedUser> TalentedUser { get; set; }
        public IEnumerable<TalentedUserViewModel> TalentedUserInfoDis { get; set; }
        public IEnumerable<ExperienceViewModel> TalentedUserExperDis { get; set; }
        public TalentedUser TalentedUserInfoDisplay { get; set; }
        public Experience TalentedUserExperienceDis { get; set; }

    }
}