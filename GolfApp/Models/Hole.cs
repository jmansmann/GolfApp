using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class Hole
    {
        public int HoleId { get; set; }
        //public int ID { get; set; }
        [Range(3, 6)]
        public int Par { get; set; }
        [Range(1, 18)]
        public int Num { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
    }
}