using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGardenApp
{
    internal class Plant
    {
        public string Name { get; set; }
        public string HarvestPeriod { get; set; }
        public string SunRequirements { get; set; }
        public string WaterRequirements { get; set; }
        public string HardinessZone { get; set; }

        public Plant(string name)
        {
            Name = name;
        }
    }
}
