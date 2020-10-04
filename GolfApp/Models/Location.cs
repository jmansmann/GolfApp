using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GolfApp.Models
{
    public class Location
    {
       public int LocationId { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(50)]
        public string City { get { return city; } set { city = value; } }
        private string city;

        [Display(Name = "Zip Code")]
        [Range(10000, 99999)]
        public int ZipCode { get { return zipCode; } set { zipCode = value; } }
        private int zipCode;
        public string UniqueName { get { return city + ", " + zipCode.ToString(); } }
    }
}