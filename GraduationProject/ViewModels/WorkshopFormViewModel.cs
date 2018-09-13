using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduationProject.ViewModels
{
    public class WorkshopFormViewModel
    {
        public int JobPostId { get; set; }
        public string TalentedId { get; set; }

        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "City")]
        public string city { get; set; }


        [Required]
        [Display(Name = "Why dou you want to attend this workshop?")]
        public string Question1 { get; set; }

        [Required]
        [Display(Name = "What do you expect?")]
        public string Question2 { get; set; }


    }
}