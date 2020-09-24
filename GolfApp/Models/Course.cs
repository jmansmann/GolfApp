using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfApp.Models
{
    public class Course
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        //public int ID { get; set; }

        public string Name { get; set; }

        public int? LocationId { get; set; }

        public Location Location { get; set; }

        [Range(1,100)]
        public int Par { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Founded")]
        public DateTime? DateFounded { get; set; }
        public ICollection<Hole> Holes { get; set; }
        public CourseType? Type { get; set; }
    }
}