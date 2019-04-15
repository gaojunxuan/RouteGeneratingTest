using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteGeneratingTest
{
    public class VerticesGroup
    {
        public Vertex From { get; set; }
        public IList<(Vertex, double)> Dist { get; set; }
    }
}
