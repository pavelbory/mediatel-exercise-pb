using MediatelExercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediatelExercise1.Helpers
{
    public class MapRequestsHelper
    {
        public static double ConvertLatitude(int deg, int min, int sec, LatitudeDirection direction)
        {
            var result =  direction == LatitudeDirection.N ? ConvertToDecimal(deg, min, sec) : ConvertToDecimal(deg, min, sec) * (-1);
            return result > 90 ? 90 : result;
        }

        public static double ConvertLongitude(int deg, int min, int sec, LongitudeDirection direction)
        {
            var result = direction == LongitudeDirection.E ? ConvertToDecimal(deg, min, sec) : ConvertToDecimal(deg, min, sec) * (-1);
            return result > 180 ? 180 : result;
        }

        public static double ConvertToDecimal(int deg, int min, int sec)
        {
            return (deg + min / 60.0 + sec / 3600.0);
        }
    }
}