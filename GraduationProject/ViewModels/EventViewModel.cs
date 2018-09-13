using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GraduationProject.ViewModels
{
    public class EventViewModel
    {

        public IEnumerable<Event> Event { get; set; }
        public IEnumerable<Tags> Tags { get; set; }
        public IEnumerable<EventUserTable> EventTags { get; set; }
       

        // public IEnumerable<TagUserTable> postTags { get; set; }

        public int Id { get; set; }

        [Display(Name = "Event Name")]
        public string Event_Name { get; set; }

        [Display(Name = "Location")]
        public string Event_Location { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateTime Event_Date { get; set; }

        public string[] SselectVal { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm.ff}", ApplyFormatInEditMode = true)]
        [Display(Name = "Open From")]
        [Required]
        public DateTime Event_From { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm.ff}", ApplyFormatInEditMode = true)]
        [Display(Name = "To")]
        public DateTime Event_To { get; set; }


        [Display(Name = "Description")]
        public string Event_Description { get; set; }

        public ILookup<int, Attendance> Attendances { get; set; }
    }
}