using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediatelExercise1.Entities
{
    public class MapSearchResult
    {
        [Key,ForeignKey("MapRequest")]
        public int MapRequestId { get; set; }
        public DateTime DateCreate { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        // TODO comment
        public string ResultCode { get; set; }

        public virtual MapRequest MapRequest { get; set; }
    }
}