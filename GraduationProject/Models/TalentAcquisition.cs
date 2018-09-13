using System;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class TalentAcquisition
    {
        public int Id { get; set; }


        public ApplicationUser Talented { get; set; }

        [Required]
        public string TalentedId { get; set; }

        [Display(Name = "First Name")]
        public string TA_FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string TA_LastName { get; set; }
        [Display(Name = "Email")]
        public string TA_Email { get; set; }
        [Display(Name = "Company")]
        public string TA_Company { get; set; }
        
        [Display(Name = "Nationality")]
        public string TA_Nationality { get; set; }
       
        [Display(Name = "Company Description")]
        public string TA_CompanyDescription { get; set; }
        [Display(Name = "Skills")]
        public string TA_Searching { get; set; }

        public Byte[] TA_Avatar { get; set; }
    }
}