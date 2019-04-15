using RouteGeneratingTest.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteGeneratingTest
{
    public class RouteGenerator
    {
        /// <summary>
        /// Create a new instance of RouteGenerator
        /// </summary>
        /// <param name="days">Total days of the trip</param>
        /// <param name="maxTime">Max time per day in minutes</param>
        /// <param name="vertices">List of vertices</param>
        public RouteGenerator(int days, double maxTime, IList<Vertex> vertices)
        {
            this.MaxTime = maxTime;
            this.Days = days;
            this.Vertices = vertices;
        }
        public double MaxTime { get; }
        public int Days { get; }
        public IList<Vertex> Vertices { get; }

        private IList<VerticesGroup> _distList;
        /// <summary>
        /// Create and sort the distance list
        /// </summary>
        private void ProcessData()
        {
            _distList = new List<VerticesGroup>();
            foreach(var v in Vertices)
            {
                var dist = new List<(Vertex, double)>();
                foreach(var j in Vertices)
                {
                    double d = Geo.Distance(v.Lat, v.Lon, j.Lat, j.Lon);
                    if(d != 0)
                    {
                        dist.Add((j, d));
                    }
                }
                dist.Sort((a,b) => 
                {
                    return (int)(a.Item2 - b.Item2);
                });
                _distList.Add(new VerticesGroup() { From = v, Dist = dist });
            }
        }
        /// <summary>
        /// Generate route
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<Vertex>> Generate()
        {
            ProcessData();
            List<int> visited = new List<int>();
            Dictionary<int, List<Vertex>> resultDict = new Dictionary<int, List<Vertex>>();
            for(int i = 0; i < this.Days; i++)
            {
                List<Vertex> result = new List<Vertex>();
                // Reset currentTime for each day
                double currentTime = 0;
                // Start from hotel and append it into result list
                Vertex hotel = Vertices.Where(v => v.IsHotel).FirstOrDefault();
                Vertex currentVertex = hotel;
                result.Add(currentVertex);
                // Reset the counter
                int counter = 0;
                // Keep connecting vertices
                // until currentTime exceeds or every possible vertices have been tested and none of them can make a route
                while (currentTime <= MaxTime && counter < (_distList.Count - 1))
                {
                    var dist = this._distList.Where(v => v.From.Id == currentVertex.Id).FirstOrDefault().Dist;
                    for (int j = 0; j < dist.Count; j++)
                    {
                        var vertex = dist.ElementAt(j);
                        counter++;
                        // Connect the current vertex (i.e. dist[j]) to the previous one
                        // if current vertex hasn't been visited, time doesn't exceed and it's not a hotel vertex
                        if (!visited.Contains(vertex.Item1.Id) && (currentTime + vertex.Item1.Time) <= MaxTime && vertex.Item1.IsHotel == false)
                        {
                            // Update previous vertex (denoted by "currentVertex"), currentTime and reset the counter
                            currentVertex = vertex.Item1;
                            visited.Add(currentVertex.Id);
                            currentTime += currentVertex.Time;
                            counter = 0;
                            result.Add(currentVertex);
                            // Stop iterating over the dist list if the nearest vertex which meets the requirement is found
                            break;
                        }
                    }
                }
                result.Add(hotel);
                resultDict.Add(i + 1, result);
            }
            return resultDict;
        }
    }
}
