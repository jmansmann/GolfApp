using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfApp.Models.ViewModels
{
    public class CourseDateFoundedGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DateFounded { get; set; }
        public int CourseCount { get; set; }
    }
}
