using GraduationProject.Models;
using System.Collections.Generic;

namespace GraduationProject.ViewModels
{
    public class HomeViewModel
    {
        public string SearchTerm { get; set; }  
        public IEnumerable<PostTable> Posts { get; set; }
        public IEnumerable<Tags> Tags { get; set; }
        public IEnumerable<TagUserTable> postTags { get; set; }
        public IEnumerable<TalentAcquisition> TalentAcquisition { get; set; }
        public IEnumerable<JobApplicationPost> JobApplicationPost { get; set; }
        public IEnumerable<TalentedUser> TalentedUser { get; set; }
        public IEnumerable<AboutMeTagsUSerTable> AboutMeTagsUSerTable { get; set; }

        public IEnumerable<Event> Event { get; set; }
        public IEnumerable<EventUserTable> EventUserTable { get; set; }
        public IEnumerable<Workshops> Workshops { get; set; }
        public IEnumerable<WorkshopUserTable> WorkshopUserTable { get; set; }   


    }
}