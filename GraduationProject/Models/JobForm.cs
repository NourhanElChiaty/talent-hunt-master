using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class JobForm
    {
        public int Id { get; set; }

        public ApplicationUser TalentedUser { get; set; }

        public string TalentedUserId { get; set; }

        public JobApplicationPost JobPost { get; set; }

        public int JobPostId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Question1 { get; set; }

        [Required]
        public string Question2 { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}