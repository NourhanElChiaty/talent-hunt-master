using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.ViewModels
{
    public class WorkshopViewModel
    {
       

        public IEnumerable<Workshops> Workshop { get; set; }

        public IEnumerable<Tags> Tags { get; set; }
        public IEnumerable<WorkshopUserTable> WorkshopTags { get; set; }

        public string[] SelectVal { get; set; }


        public int Id { get; set; }

        [Display(Name = "Workshop Name")]
        public string workshop_Name { get; set; }

        [Display(Name = "Location")]
        public string workshop_Location { get; set; }

        [Display(Name = "Fees")]
        public int workshop_Fees { get; set; }

        [Display(Name = "Start Date")]
        public DateTime workshop_Date { get; set; }

        [Display(Name = "Number Of Sessions")]
        public int workshop_Sessions { get; set; }

        [Display(Name = "Description")]
        public string workshop_Description { get; set; }
    }
}