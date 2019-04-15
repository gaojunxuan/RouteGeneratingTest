using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteGeneratingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vertex> places = new List<Vertex>()
            {
                new Vertex() { Id = 0, Tag = "ウェスティンホテル東京", Lat = 35.647156, Lon = 139.709739, Time = 0, IsHotel = true },
                new Vertex() { Id = 1, Tag = "上野公園", Lat = 35.714071, Lon = 139.774079, Time = 30, IsHotel = false },
                new Vertex() { Id = 2, Tag = "浅草寺", Lat = 35.713968, Lon = 139.79645, Time = 30, IsHotel = false },
                new Vertex() { Id = 3, Tag = "東京大学", Lat = 35.712056, Lon = 139.762775, Time = 30, IsHotel = false },
                new Vertex() { Id = 4, Tag = "秋葉原", Lat = 35.702259, Lon = 139.774473, Time = 240, IsHotel = false },
                new Vertex() { Id = 5, Tag = "東京国立近代美術館", Lat = 35.690543, Lon = 139.754693, Time = 60, IsHotel = false },
                new Vertex() { Id = 6, Tag = "代々木公園", Lat = 35.672801, Lon = 139.692596, Time = 30, IsHotel = false },
                new Vertex() { Id = 7, Tag = "銀座", Lat = 35.672114, Lon = 139.770825, Time = 360, IsHotel = false },
                new Vertex() { Id = 8, Tag = "ディズニーランド", Lat = 35.635585, Lon = 139.884578, Time = 480, IsHotel = false },
                new Vertex() { Id = 9, Tag = "お台場海浜公園", Lat = 35.629686, Lon = 139.77499, Time = 30, IsHotel = false },
                new Vertex() { Id = 10, Tag = "神田明神", Lat = 35.70192, Lon = 139.76784, Time = 20, IsHotel = false },
                new Vertex() { Id = 11, Tag = "明治神宮", Lat = 35.67639, Lon = 139.69932, Time = 30, IsHotel = false },

            };
            RouteGenerator routeGen = new RouteGenerator(3,  8 * 60, places);
            var route = routeGen.Generate();
            foreach(var i in route)
            {
                System.Diagnostics.Debug.WriteLine($"Day {i.Key}:");
                foreach(var j in i.Value)
                {
                    System.Diagnostics.Debug.WriteLine($"{j.Tag}\t{j.Time}");
                }
                System.Diagnostics.Debug.WriteLine("======");
            }
        }
    }
}
