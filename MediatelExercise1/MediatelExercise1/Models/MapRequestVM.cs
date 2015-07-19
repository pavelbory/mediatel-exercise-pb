using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediatelExercise1.Models
{
    // TODO CustomValidatio na soucet slozek sirky a delky
    public class MapRequestVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "MapRequestVM_Email_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public string Email { get; set; }

        [Required]
        [Range(0, 90, ErrorMessageResourceName = "ErrorMessage_LatitudeDegrees",ErrorMessageResourceType=typeof(MediatelResources))]
        [Display(Name = "MapRequestVM_LatDegrees_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public int LatDegrees { get; set; }

        [Required]
        [Range(0, 60, ErrorMessageResourceName = "ErrorMessage_LatitudeMinutes", ErrorMessageResourceType = typeof(MediatelResources))]
        [Display(Name = "MapRequestVM_LatMinutes_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public int LatMinutes { get; set; }

        [Required]
        [Range(0, 60, ErrorMessageResourceName = "ErrorMessage_LatitudeSeconds", ErrorMessageResourceType = typeof(MediatelResources))]
        [Display(Name = "MapRequestVM_LatSeconds_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public int LatSeconds { get; set; }

        [Required]
        [Range(0, 180, ErrorMessageResourceName = "ErrorMessage_LongitudeDegrees", ErrorMessageResourceType = typeof(MediatelResources))]
        [Display(Name = "MapRequestVM_LonDegrees_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public int LonDegrees { get; set; }

        [Required]
        [Range(0, 60, ErrorMessageResourceName = "ErrorMessage_LongitudeMinutes", ErrorMessageResourceType = typeof(MediatelResources))]
        [Display(Name = "MapRequestVM_LonMinutes_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public int LonMinutes { get; set; }

        [Required]
        [Range(0, 60, ErrorMessageResourceName = "ErrorMessage_LongitudeSeconds", ErrorMessageResourceType = typeof(MediatelResources))]
        [Display(Name = "MapRequestVM_LonSeconds_DisplayLabel", ResourceType = typeof(MediatelResources))]
        public int LonSeconds { get; set; }

        public LatitudeDirection LatDirection { get; set; }

        public LongitudeDirection LonDirection { get; set; }

        public MapRequestVM()
        {

        }
    }
}