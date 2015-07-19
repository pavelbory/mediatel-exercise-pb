using MediatelExercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Configuration;
using MediatelExercise1.Helpers;
using MediatelExercise1.Entities;
using System.Web.Caching;

namespace MediatelExercise1.BusinessLogic
{
    public class MapRequests
    {
        public static MapSearchResultVM SearchForAddress(MapRequestVM mapRequestVM)
        {
            Validator.ValidateObject(mapRequestVM, new ValidationContext(mapRequestVM), true);
            MapRequest mapRequest = CreateMapRequest(mapRequestVM);
            return SearchForAddress(mapRequest);
        }

        public static MapSearchResultVM SearchForAddress(MapRequestAVM mapRequestAVM)
        {
            Validator.ValidateObject(mapRequestAVM, new ValidationContext(mapRequestAVM), true);
            MapRequest mapRequest = CreateMapRequest(mapRequestAVM);
            return SearchForAddress(mapRequest);
        }

        public static IList<MapSearchRequestHistoryVM> GetMapSearchRequestsHistory(Func<MapRequest,object> orderBy = null)
        {
            IList<MapSearchRequestHistoryVM> result = new List<MapSearchRequestHistoryVM>();
            using (MediatelModel context = new MediatelModel())
            {
                IList<MapRequest> mapRequests = null;
                if (orderBy == null)
                {
                    mapRequests = context.MapRequests.Include("MapSearchResult").OrderBy(m => m.DateCreated).ToList();
                    mapRequests = mapRequests.Reverse().ToList();
                }
                else
                {
                    mapRequests = context.MapRequests.Include("MapSearchResult").OrderBy(orderBy).ToList();
                }
                foreach (MapRequest mapRequest in mapRequests)
                {
                    var mapSerReqHis = new MapSearchRequestHistoryVM();
                    mapSerReqHis.ResultCode = mapRequest.MapSearchResult.ResultCode;
                    mapSerReqHis.City = mapRequest.MapSearchResult.City;
                    mapSerReqHis.Country = mapRequest.MapSearchResult.Country;
                    mapSerReqHis.DateCreated = mapRequest.DateCreated;
                    mapSerReqHis.Email = mapRequest.Email;
                    mapSerReqHis.HouseNumber = mapRequest.MapSearchResult.HouseNumber;
                    mapSerReqHis.Latitude = mapRequest.Latitude;
                    mapSerReqHis.Longitude = mapRequest.Longitude;
                    mapSerReqHis.PostCode = mapRequest.MapSearchResult.PostCode;
                    result.Add(mapSerReqHis);
                }
            }
            return result;
        }

        private static MapSearchResultVM SearchForAddress(MapRequest mapRequest)
        {
            string cacheKey = String.Format("{0};{1}", mapRequest.Latitude, mapRequest.Longitude);
            OSMClient.OSMReverseResponse mapSearchResponse;
            object cachedObject = HttpContext.Current.Cache.Get(cacheKey);

            if (cachedObject != null)
            {
                mapSearchResponse = cachedObject as OSMClient.OSMReverseResponse;
            }
            else 
            { 
                mapSearchResponse = OSMClient.SearchForAddressOSM(mapRequest.Latitude, mapRequest.Longitude);
                // TODO better cache configuration based on statistics of searches
                HttpContext.Current.Cache.Add(cacheKey, mapSearchResponse, null, DateTime.Now.AddDays(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }
            MapSearchResultVM mapSearchResultVM = new MapSearchResultVM();
            mapSearchResultVM.ResultCode = mapSearchResponse.ResultCode.ToString();
            if (mapSearchResponse.ResultCode == OSMClient.SearchResultCode.OK)
            {
                mapSearchResultVM.City = mapSearchResponse.Address.City;
                mapSearchResultVM.Country = mapSearchResponse.Address.Country;
                mapSearchResultVM.HouseNumber = mapSearchResponse.Address.HouseNumber;
                mapSearchResultVM.PostCode = mapSearchResponse.Address.PostCode;
            }
            CreateMapSearchResult(mapSearchResultVM, mapRequest.MapRequestId);
            return mapSearchResultVM;
        }

        private static MapRequest CreateMapRequest(MapRequestVM mapRequestVM)
        {
            double latitude = MapRequestsHelper.ConvertLatitude(mapRequestVM.LatDegrees, mapRequestVM.LatMinutes, mapRequestVM.LatSeconds, mapRequestVM.LatDirection);
            double longitude = MapRequestsHelper.ConvertLongitude(mapRequestVM.LonDegrees, mapRequestVM.LonMinutes, mapRequestVM.LonSeconds, mapRequestVM.LonDirection);
            var mapRequest = new MapRequest(mapRequestVM.Email, latitude, longitude,DateTime.Now);
            using (MediatelModel context = new MediatelModel())
            {
                context.MapRequests.Add(mapRequest);
                context.SaveChanges();
            }
            return mapRequest;
        }

        private static MapRequest CreateMapRequest(MapRequestAVM mapRequestAVM)
        {
            var mapRequest = new MapRequest(mapRequestAVM.Email, mapRequestAVM.Latitude.Value, mapRequestAVM.Longitude.Value,DateTime.Now);
            using (MediatelModel context = new MediatelModel())
            {
                context.MapRequests.Add(mapRequest);
                context.SaveChanges();
            }
            return mapRequest;
        }

        private static MapSearchResult CreateMapSearchResult(MapSearchResultVM mapSearchResultVM, int mapRequestId)
        {
            MapSearchResult mapSearchResult = new MapSearchResult();
            mapSearchResult.City = mapSearchResultVM.City;
            mapSearchResult.Country = mapSearchResultVM.Country;
            mapSearchResult.DateCreate = DateTime.Now;
            mapSearchResult.HouseNumber = mapSearchResultVM.HouseNumber;
            mapSearchResult.MapRequestId = mapRequestId;
            mapSearchResult.PostCode = mapSearchResultVM.PostCode;
            mapSearchResult.ResultCode = mapSearchResultVM.ResultCode;
            using (MediatelModel context = new MediatelModel())
            {
                context.MapSearchResults.Add(mapSearchResult);
                context.SaveChanges();
            }
            return mapSearchResult;
        }


    }
}