using Core.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Country
    {
        private static int _countryid = 0;
        public int Id { get; set; }
        public string CountryName { get; set; }
        public double CountryArea { get; set; }
        public string CountryAnthem { get; set; }
        public Region Region { get; set; }


        public Country(string countryName, double area, string anthem, Region region)
        {
            _countryid++; 
            Id = _countryid;
            CountryName = countryName;
            CountryArea = area;
            CountryAnthem = anthem;    
            Region = region;    
        }

        public string showInfo()
        {
            return $"Country id: {Id} \nCountry Name: {CountryName} \nCountry Area: {CountryArea}\n \nCountry Anthem: {CountryAnthem} \nCountry Region: {Region}\n";
        }
        public override string ToString()
        {
            return showInfo();
        }
    }
}
