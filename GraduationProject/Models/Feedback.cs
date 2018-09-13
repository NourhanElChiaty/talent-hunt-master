using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class Feedback
    {
        public ApplicationUser Talented { get; set; }

        [Required]
        public string TalentedId { get; set; }

        public int Id { get; set; }

        [Required]
        public string Message { get; set; }
    }
}