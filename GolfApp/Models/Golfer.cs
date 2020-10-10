using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class Golfer
    {
        public int GolferId { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        public Sex Sex { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Display(Name = "Rounds Played")]
        public ICollection<Round>? RoundsPlayed { get; set; }

    }

    public enum Sex
    {
        Male,
        Female,
        Disclosed,
        LGBQT
    }
}