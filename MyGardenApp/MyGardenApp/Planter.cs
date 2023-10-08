using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MyGardenApp
{
    internal class Planter
    {
        public string Name { get; set; }
        public List<Plant> Plants { get; set; }

        public Planter(string name)
        {
            Name = name; //sets the instance name to the given value
            Plants = new List<Plant>(); //initialises the Plants list
        }

        public void AddPlant(string name)
        {
            Plants.Add(new Plant(name)); //adds a new plant with given name to the planter 
        }
    }
}
