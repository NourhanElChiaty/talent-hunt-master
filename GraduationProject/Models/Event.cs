using System;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class Event
    {
        public ApplicationUser Talented { get; set; }

        [Required]
        public string TalentedId { get; set; }
        public DateTime DateTime { get; set; }

        public int Id { get; set; }
        public string Event_Name { get; set; }
        public string Event_Location { get; set; }

        public DateTime Event_Date { get; set; }
        public DateTime Event_From { get; set; }
        public DateTime Event_To { get; set; }
        public string Event_Description { get; set; }
        public TalentedUser Talenteduser { get; set; }
        public int TU_Id { get; set; }
    }
}