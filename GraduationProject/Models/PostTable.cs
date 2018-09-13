using System;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class PostTable
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public Byte[] Imagepath { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public ApplicationUser User { get; set; }

        public string Userid { get; set; }

       

    }
}