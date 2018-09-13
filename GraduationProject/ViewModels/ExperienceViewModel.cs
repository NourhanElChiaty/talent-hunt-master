using System.ComponentModel.DataAnnotations;

namespace GraduationProject.ViewModels
{
    public class ExperienceViewModel
    {
        [Required]
        public string TalentedId { get; set; }
        public int Id { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Skills { get; set; }
    }
}