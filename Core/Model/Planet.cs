using Core.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Planet
    {
        private static int _planetid = 0;
        public int Id { get; set; }
        public string PlanetName { get; set; }
        public double PlanetArea { get; set; }


        public Planet(string planetName, double planetArea)
        {
            _planetid++;
            Id = _planetid;
            PlanetName = planetName;
            PlanetArea = planetArea;
        }
        public string showInfo()
        {
            return $"Planet id: {Id} \nPlanet Name: {PlanetName} \nPlanet Area: {PlanetArea}\n"; 
        }
        public override string ToString()
        {
            return showInfo();
        }
    }
}
