namespace GraduationProject.Models
{
    public class TagUserTable
    {
        public int Id { get; set; }

        public Tags Tags { get; set; }

        public int Tagsid { get; set; }

        public ApplicationUser User { get; set; }
        public string Userid { get; set; }

        public PostTable post { get; set; }

        public int postid { get; set; }
    }
}