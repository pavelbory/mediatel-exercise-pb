using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediatelExercise1.Entities
{
    public class MapRequest
    {
        [Key]
        public int MapRequestId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(-90, 90, ErrorMessageResourceName = "ErrorMessage_LatitudeDecimal",ErrorMessageResourceType=typeof(MediatelResources))]
        public double Latitude { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessageResourceName = "ErrorMessage_LongitudeDecimal", ErrorMessageResourceType = typeof(MediatelResources))]
        public double Longitude { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual MapSearchResult MapSearchResult { get; set; }

        public MapRequest()
        {

        }

        public MapRequest(string email, double latitude, double longitude,DateTime dateCreated)
        {
            Email = email;
            Latitude = latitude;
            Longitude = longitude;
            DateCreated = dateCreated;
        }
    }
}