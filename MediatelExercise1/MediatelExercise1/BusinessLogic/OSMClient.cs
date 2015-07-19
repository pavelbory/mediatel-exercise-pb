using MediatelExercise1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace MediatelExercise1.BusinessLogic
{
    public class OSMClient
    {
        #region Configuration Properties
        public static string OSMHost
        {
            get
            {
                return ConfigurationManager.AppSettings["OSMHost"];
            }
        }

        public static string OSMPathReverse
        {
            get
            {
                return ConfigurationManager.AppSettings["OSMPathReverse"];
            }
        }

        public static string OSMReverseParLongitude
        {
            get
            {
                return ConfigurationManager.AppSettings["OSMReverseParLongitude"];
            }
        }

        public static string OSMReverseParLatitude
        {
            get
            {
                return ConfigurationManager.AppSettings["OSMReverseParLatitude"];
            }
        }

        public static string OSMReverseParFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["OSMReverseParFormat"];
            }
        }

        private static readonly string OSMReverserFormat = "json";

        #endregion

        #region JSON Data Classes for communication with OSM

        public class OSMReverseResponse
        {
            public OSMReverseResponseAddress Address { get; set; }
            public SearchResultCode ResultCode { get; set; }
            [JsonProperty("error")]
            public string ErrorMessage { get; set; }

        }

        public class OSMReverseResponseAddress
        {
            public string City { get; set; }
            [JsonProperty("house_number")]
            public string HouseNumber { get; set; }
            public string PostCode { get; set; }
            public string Country { get; set; }

            
        }

        #endregion

        public enum SearchResultCode
        {
            OK,
            NOT_FOUND,
            EXCEPTION
        }

        public static OSMReverseResponse SearchForAddressOSM(double latitude, double longitude)
        {
            OSMReverseResponse resultContent = null;
            try
            {
                HttpClient httpClient = new HttpClient();
                UriBuilder uriBuilder = new UriBuilder();
                uriBuilder.Host = OSMHost;
                uriBuilder.Path = OSMPathReverse;
                uriBuilder.Query = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0}={1}&{2}={3}&{4}={5}", OSMReverseParLatitude, latitude, OSMReverseParLongitude, longitude, OSMReverseParFormat, OSMReverserFormat);


                var result = httpClient.GetAsync(uriBuilder.Uri).Result;
                resultContent = JsonConvert.DeserializeObject<OSMReverseResponse>(result.Content.ReadAsStringAsync().Result);
                if (String.IsNullOrEmpty(resultContent.ErrorMessage))
                {
                    resultContent.ResultCode = SearchResultCode.OK;
                }
                else
                {
                    resultContent.ResultCode = SearchResultCode.NOT_FOUND;
                }
            }
            catch (Exception e)
            {
                resultContent.ResultCode = SearchResultCode.EXCEPTION;
            }
            return resultContent;
        }
    }
}