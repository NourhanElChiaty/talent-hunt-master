using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.ViewModels
{
    public class PoostViewModel
    {

      public  IEnumerable<PostTable> Posts { get; set; }
      public  IEnumerable<Tags> Tags { get; set; }
      public IEnumerable<TagUserTable> postTags {get; set;}


        public int id { get; set; }

        public string ActionName
        {
            get
            {
                return (id != 0) ? "Update" : "Post";
            }
        }

        [Required]
        public string Title { get; set; }

        public Byte[] Imagepath { get; set; }

        public string[] SelectVal { get; set; }
        public List<Tags> Tagslist { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }


        public string Userid { get; set; }


        public Tags tag { get; set; }
    }

    
}