using System.ComponentModel.DataAnnotations;

namespace GraduationProject.ViewModels
{
    public class JobFormViewModel
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
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Why Should We Hire You?")]
        public string Question1 { get; set; }

        [Required]
        [Display(Name = "Describe yourself in one sentence")]
        public string Question2 { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }
}