using System;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class TalentedUser
    {
        public int Id { get; set; }


        public ApplicationUser Talented { get; set; }

        [Required]
        public string TalentedId { get; set; }

        [Display(Name = "First Name")]
        public string TU_FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string TU_LastName { get; set; }
        [Display(Name = "Email")]
        public string TU_Email { get; set; }
        [Display(Name = "School/Umiversity")]
        public string TU_School { get; set; }
        [Display(Name = "Date OF Birth")]
        public DateTime? TU_DOB { get; set; }
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
    }
}