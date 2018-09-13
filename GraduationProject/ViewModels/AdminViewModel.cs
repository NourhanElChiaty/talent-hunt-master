using GraduationProject.Models;
using System.Collections.Generic;

namespace GraduationProject.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<Tags> Tags { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Event> Event { get; set; }
        public IEnumerable<Workshops> Workshops { get; set; }
        public IEnumerable<PostTable > PostTable { get; set; }
        public IEnumerable<Feedback> Feedback { get; set; }



    }
}