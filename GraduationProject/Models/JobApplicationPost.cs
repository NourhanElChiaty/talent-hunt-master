using System;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class JobApplicationPost
    {

        public int Id { get; set; }

        public ApplicationUser Talented { get; set; }

        [Required]
        public string TalentedId { get; set; }

        public string JobTitle { get; set; }

        public string JobLocation { get; set; }

        public string JobCategory { get; set; }

        public string EmploymentType { get; set; }

        public string JobDescription { get; set; }

        public string JobRequirements { get; set; }

        public string Question { get; set; }

        public string Benifits { get; set; }

        public DateTime DateTime { get; set; }

    }
}