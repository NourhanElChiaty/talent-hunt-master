using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.ViewModels
{
    public class TalentAcquisitionViewModel
    {

        public IEnumerable<TalentAcquisition> TalentedAcquisition { get; set; }
        public IEnumerable<JobApplicationPost> JobApplicationPost { get; set; }


        public int TA_Id { get; set; }


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
        [Display(Name = "What Am I Searching For")]
        public string TA_Searching { get; set; }

        public Byte[] TA_Avatar { get; set; }


        public int id { get; set; } 

        public string JobTitle { get; set; }

        public string JobLocation { get; set; }

        public string JobCategory { get; set; }

        public string EmploymentType { get; set; }

        public string JobDescription { get; set; }

        public string JobRequirements { get; set; }
        [Display(Name = "What I Am Searching For")]
        public string Question { get; set; }

        public string Benifits { get; set; }


        public DateTime Datetime { get; set; }
       

        public int Feedback_Id { get; set; }

        [Required]
        public string Message { get; set; }
    }
}