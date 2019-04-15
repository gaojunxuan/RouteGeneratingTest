using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteGeneratingTest.Utils
{
    public static class Geo
    {
        const double R = 6371e3;
        public static double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double phi1 = DegreeToRadian(lat1);
            double phi2 = DegreeToRadian(lat2);
            double phi3 = DegreeToRadian(lat2 - lat1);
            double lam = DegreeToRadian(lon2 - lon1);
            double a = Math.Sin(phi3 / 2) * Math.Sin(phi3 / 2) + Math.Cos(phi1) * Math.Cos(phi2) * Math.Sin(lam / 2) * Math.Sin(lam / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
