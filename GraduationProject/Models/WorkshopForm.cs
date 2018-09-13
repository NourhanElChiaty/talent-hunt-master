using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class WorkshopForm
    {
        public int Id { get; set; }
        public ApplicationUser TalentedUser { get; set; }

        public string TalentedUserId { get; set; }

        public Workshops workshop { get; set; }

        public int WorkshopId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string city { get; set; }


        [Required]
        public string Question1 { get; set; }

        [Required]
        public string Question2 { get; set; }

    }
    }