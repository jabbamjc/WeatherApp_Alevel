using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    internal class Planter
    {
        public string Name { get; set; }
        public Plant[] Plants { get; set; }

        public Planter(string name)
        {
            Name = name;
        }
    }
}
