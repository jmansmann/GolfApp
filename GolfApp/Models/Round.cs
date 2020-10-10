using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfApp.Models
{
    public class Round
    {
        public int RoundId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Played")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DatePlayed { get; set; }
        
        public int CourseId { get; set; }

        [Display(Name = "Course Played")]
        public Course CoursePlayed { get; set; }
        
        public int Score { get; set; }

        public int GolferId { get; set; }

        public Golfer Golfer { get; set; }

        public ICollection<Hole>? HolesPlayed { get; set; }

        public ICollection<HoleScore>? ScoresOfHoles { get; set; }

    }

    public class HoleScore
    {
        public int HoleScoreId { get; set; }

        public int HoleId { get; set; }
        public Hole Hole { get; set; }

        public int Score { get; set; }
    }

}
