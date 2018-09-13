using System;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class Workshops
    {

        public ApplicationUser Talented { get; set; }

        [Required]
        public string TalentedId { get; set; }
        public int Id { get; set; }
        public string workshop_Name { get; set; }
        public string workshop_Location { get; set; }
        public int workshop_Fees { get; set; }
        public DateTime workshop_Date { get; set; }
        public int workshop_Sessions { get; set; }
        public string workshop_Description { get; set; }
        public DateTime DateTime { get; set; }
        public TalentedUser Talenteduser { get; set; }
        public int TU_Id { get; set; }
    }
}