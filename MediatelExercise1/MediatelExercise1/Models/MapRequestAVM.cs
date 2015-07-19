using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediatelExercise1.Models
{
    public class MapRequestAVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(-90, 90)]
        public double? Latitude { get; set; }
        
        [Required]
        [Range(-180,180)]
        public double? Longitude { get; set; }

    }
}