using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class WorkshopUserTable
    {
        public int Id { get; set; }

        public Tags Tags { get; set; }

        public int Tagsid { get; set; }

        public ApplicationUser User { get; set; }
        public string Userid { get; set; }

        public Workshops Workshops { get; set; }

        public int Workshopid { get; set; } 
    }
}