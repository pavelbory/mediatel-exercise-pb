using MediatelExercise1.BusinessLogic;
using MediatelExercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace MediatelExercise1.Controllers
{
    public class MapsApiController : ApiController
    {
        [HttpPost]
        public object SearchAddress([FromBody]MapRequestAVM value)
        {
            try
            {
                var result = MapRequests.SearchForAddress(value);
                switch((OSMClient.SearchResultCode)Enum.Parse(typeof(OSMClient.SearchResultCode), result.ResultCode))
                {
                    case OSMClient.SearchResultCode.OK:
                        return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result));
                    case OSMClient.SearchResultCode.NOT_FOUND:
                        return Request.CreateResponse(HttpStatusCode.NotFound, JsonConvert.SerializeObject(result));
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unexpected internal server error during map search");
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
