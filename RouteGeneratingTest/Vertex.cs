using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteGeneratingTest
{
    public class Vertex
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Time { get; set; }
        public bool IsHotel { get; set; }
    }
}
