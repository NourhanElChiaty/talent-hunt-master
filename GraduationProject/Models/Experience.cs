using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class Experience
    {
        public ApplicationUser Talented { get; set; }

        [Required]
        public string TalentedId { get; set; }
        public int Id { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Skills { get; set; }

        public TalentedUser Talenteduser { get; set; }
        public int TU_Id { get; set; }
    }
}