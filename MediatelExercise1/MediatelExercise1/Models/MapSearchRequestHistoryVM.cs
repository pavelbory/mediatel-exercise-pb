using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediatelExercise1.Models
{
    public class MapSearchRequestHistoryVM
    {
        [Display(Name = "MapSearchRequestHistoryVM_Email_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public string Email { get; set; }
        [Display(Name = "MapSearchRequestHistoryVM_DateCreated_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public DateTime DateCreated { get; set; }
        [Display(Name = "MapSearchRequestHistoryVM_Latitude_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public double Latitude { get; set; }
        [Display(Name = "MapSearchRequestHistoryVM_Longitude_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public double Longitude { get; set; }
        [Display(Name = "MapSearchRequestHistoryVM_ResultCode_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public string ResultCode { get; set; }
        [Display(Name = "MapSearchRequestHistoryVM_Country_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public string Country { get; set; }
        [Display(Name = "MapSearchRequestHistoryVM_City_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public string City { get; set; }
        [Display(Name = "MapSearchRequestHistoryVM_HouseNumber_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public string HouseNumber { get; set; }
        [Display(Name = "MapSearchRequestHistoryVM_PostCode_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public string PostCode { get; set; }
    }
}