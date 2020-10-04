using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? LocationId { get; set; }

        public Location Location { get; set; }

        [Range(1,100)]
        [Required]
        public int Par { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Founded")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? DateFounded { get; set; }

        public ICollection<Hole> Holes { get; set; }

        [Required]
        public CourseType? Type { get; set; }
    }
}