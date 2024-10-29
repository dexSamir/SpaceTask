using Core.Helper.Enum;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public static class AppDbContext
    {
        static List<Country> Countries = new List<Country>();
        static List<Planet> Planets = new List<Planet>();

        public static void CreateCountry(Country country)
        {
            Countries.Add(country);
        }

        public static void UpdateCountry(int? id, string? countryName, double? countryArea, string? countryAnthem, Region? region)
        {

            if (id.HasValue && checkCountry(id.Value))
            {
                if (countryName != null)
                    Countries[id.Value - 1].CountryName = countryName;

                if (countryArea.HasValue)
                    Countries[id.Value - 1].CountryArea = countryArea.Value;

                if (countryAnthem != null)
                    Countries[id.Value - 1].CountryAnthem = countryAnthem;

                if (region.HasValue)
                    Countries[id.Value - 1].Region = region.Value;
            }
            else
            {
                Console.WriteLine("Verilen Id-ye uygun olke tapilmadi!\n");
            }
        }
        public static bool checkCountry(int id)
        {
            return id > 0 && id <= Countries.Count; 
        }

        public static void RemoveCountry(int id)
        {
            Countries.RemoveAt(id);
            Console.WriteLine($"{Countries[id].CountryName} adli olke silindi!\n");   
        }

        public static void GetAllCountries()
        {
            foreach (var country in Countries)
            {
                Console.WriteLine(country.ToString());
            }
        }

        public static List<Country> GetCountryByRegion(Region region)
        {
            Countries.FindAll(country => country.Region == region); 
            return Countries;
        }

        public static void CreatePlanet(Planet planet)
        {
            Planets.Add(planet);
        }


        public static void GetAllPlanets()
        {
            foreach (var planet in Planets)
            {
                Console.WriteLine(planet.ToString());
            }
        }
        public static void UpdatePlanet(int? id, string? planetName, double? planetArea)
        {
            if (id.HasValue && checkPlanet(id.Value))
            {
                if (planetName != null)
                    Planets[id.Value - 1].PlanetName = planetName;

                if (planetArea.HasValue)
                    Planets[id.Value - 1].PlanetArea = planetArea.Value;
            }
        }
        public static bool checkPlanet(int id)
        {
            return id >= 1 && id <= Planets.Count;
        }
    }
}
