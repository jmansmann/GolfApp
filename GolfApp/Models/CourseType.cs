using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public enum CourseType
    {
        [Display(Name = "Links")]
        Links,
        [Display(Name = "Executive")]
        Executive,
        [Display(Name = "Pitch And Putt")]
        PitchAndPutt
    }
}