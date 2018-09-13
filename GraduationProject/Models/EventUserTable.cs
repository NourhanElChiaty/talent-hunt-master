namespace GraduationProject.Models
{
    public class EventUserTable
    {
        public int Id { get; set; }

        public Tags Tags { get; set; }

        public int Tagsid { get; set; }

        public ApplicationUser User { get; set; }
        public string Userid { get; set; }

        public Event Event { get; set; }

        public int Eventid { get; set; }
    }
}