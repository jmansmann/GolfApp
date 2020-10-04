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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

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