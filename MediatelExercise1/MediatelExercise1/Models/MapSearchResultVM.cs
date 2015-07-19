using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediatelExercise1.Models
{
    public class MapSearchResultVM
    {
        public string ResultCode { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}