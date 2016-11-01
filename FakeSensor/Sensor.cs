using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSensor
{
    class Sensor
    {
        public int id { get; set; }
        public double lt { get; set; }
        public double lg { get; set; }
        public Dictionary<string,int> gasArray { get; set; }
    }
}
