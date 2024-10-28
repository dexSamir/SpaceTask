using Core.Data;
using Core.Helper.Enum;
using Core.Model;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsMainLoop = false;
            string planetName;
            double PlanetArea;
            string UpdateplanetName;
            double UpdatePlanetArea;
            int planetId;


            string countryName;
            string countryAnthem; 
            Region region = new Region();
            double countryArea;

            string UpadatedcountryName;
            string UpdatedcountryAnthem;
            Region Uopdatedregion = new Region();
            double UpdatedcountryArea;
            int COuntryId; 
            do
            {
                Console.WriteLine("1. Planet Menu \n2. Country Menu \n0. EXIT");
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":

                        bool isPlanetLoop = false;
                        do
                        {
                            Console.WriteLine("1. Planet Yarat \n2. Butun Planetleri gor \n3. Planetin melumatlarini yenile \n0. EXIT\n");
                            string choise2 = Console.ReadLine();

                            switch (choise2)
                            {
                                case "1":
                                    Console.WriteLine("Planetin adini daxil edin: ");
                                    planetName = Console.ReadLine();

                                    Console.WriteLine("Planetin sahesini daxil edin: ");
                                    bool isFalse = double.TryParse(Console.ReadLine(), out PlanetArea);

                                    while(!isFalse)
                                    {
                                        Console.WriteLine("Planetin sahesini duzdun daxil edin!!!");
                                        isFalse = double.TryParse(Console.ReadLine(), out PlanetArea);
                                    }
                                    Planet planet = new Planet(planetName, PlanetArea);
                                    AppDbContext.CreatePlanet(planet);
                                    Console.WriteLine($"{planetName} adli planet yaradildi!");

                                    break;
                                case "2":
                                    AppDbContext.GetAllPlanets(); 
                                    break;

                                case "0":
                                    isPlanetLoop = true;
                                    break;
                                case "3":
                                    Console.WriteLine("Planetin Id-sini daxil edin: ");
                                    isFalse = int.TryParse(Console.ReadLine(), out planetId);

                                    while (!isFalse)
                                    {
                                        Console.WriteLine("Planetin id-ni duzgun daxil edin!!!");
                                        isFalse = int.TryParse(Console.ReadLine(), out planetId);
                                    }
                                    Console.WriteLine("Planetin yeni adini daxil edin: ");
                                    UpdateplanetName = Console.ReadLine();

                                    Console.WriteLine("Planetin yeni sahesini daxil edin: ");
                                    isFalse = double.TryParse(Console.ReadLine(), out UpdatePlanetArea);

                                    while (!isFalse)
                                    {
                                        Console.WriteLine("Planetin sahesini duzdun daxil edin!!!");
                                        isFalse = double.TryParse(Console.ReadLine(), out UpdatePlanetArea);
                                    }

                                    AppDbContext.UpdatePlanet(planetId, UpdateplanetName, UpdatePlanetArea);
                                    break;
                                default:
                                    Console.WriteLine("Bele emeliyyat yoxdur!!");
                                    break;
                            }
                        }
                        while (!isPlanetLoop);
                        break;
                    case "2":
                        bool iscountryLoop = false;

                        do
                        {
                            Console.WriteLine("1. Country Yarat \n2. Butun Olkeleri gor \n3. Olkelerin melumatlarini yenile \n0. EXIT \n");
                            string choise3 = Console.ReadLine();

                            switch (choise3)
                            {
                                case "1":
                                    Console.WriteLine("Olkenin adini daxil edin: ");
                                    countryName = Console.ReadLine();

                                    Console.WriteLine("Olkenin himini daxil edin: ");
                                    countryAnthem = Console.ReadLine();


                                    Console.WriteLine("Olkenin sahesini daxil edin: ");
                                    bool isFalse = double.TryParse(Console.ReadLine(), out countryArea);

                                    while (!isFalse)
                                    {
                                        Console.WriteLine("Olkenin sahesini duzdun daxil edin!!!");
                                        isFalse = double.TryParse(Console.ReadLine(), out countryArea);
                                    }
                                    bool isRegionLoop; 
                                    Console.WriteLine("Olkenin regionunu secin: ");
                                    do
                                    {
                                        Console.WriteLine("1.Asia  2.Africa 3.North America 4.South America 5.Antarctica 6.Europe 7.Australia  0.Legv et");

                                        string chooseRegion = Console.ReadLine();

                                        switch (chooseRegion)
                                        {
                                            case "1": 
                                                region = Region.Asia;
                                                break;

                                            case "2":
                                                region = Region.Africa;
                                                break;
                                            case "3":
                                                region = Region.NorthAmerica;
                                                break;
                                            case "4":
                                                region = Region.SouthAmerica;
                                                break;
                                            case "5":
                                                region = Region.Antarctica;
                                                break;
                                            case "6":
                                                region = Region.Europe;
                                                break;
                                            case "7":
                                                region = Region.Australia;
                                                break;
                                            case "0":
                                                isRegionLoop = true;    
                                                break;
                                            default:
                                                Console.WriteLine("Bele bir emeliyat yoxdur!");
                                                break;
                                        }
                                        break;
                                    }
                                    while (!isRegionLoop);

                                    Country country = new Country(countryName, countryArea, countryAnthem, region);
                                    AppDbContext.CreateCountry(country); 

                                    break; 
                                case "2":
                                    AppDbContext.GetAllCountries(); 
                                    break;
                                case "3":
                                    Console.WriteLine("Cpuntry Id-sini daxil edin: ");
                                    isFalse = int.TryParse(Console.ReadLine(), out planetId);

                                    while (!isFalse)
                                    {
                                        Console.WriteLine("Country id-ni duzgun daxil edin!!!");
                                        isFalse = int.TryParse(Console.ReadLine(), out planetId);
                                    }
                                    Console.WriteLine("Country yeni adini daxil edin: ");
                                    UpadatedcountryName = Console.ReadLine();

                                    Console.WriteLine("Planetin yeni sahesini daxil edin: ");
                                    isFalse =  double.TryParse(Console.ReadLine(), out UpdatedcountryArea);

                                    while (!isFalse)
                                    {
                                        Console.WriteLine("Planetin sahesini duzdun daxil edin!!!");
                                        isFalse = double.TryParse(Console.ReadLine(), out UpdatedcountryArea);
                                    }

                                    Console.WriteLine("Country yeni himnini daxil edin: ");
                                    UpdatedcountryAnthem = Console.ReadLine();
                                    bool isRegionchooseLoop;
                                    Console.WriteLine("Olkenin regionunu secin: ");
                                    do
                                    {
                                        Console.WriteLine("1.Asia  2.Africa 3.North America 4.South America 5.Antarctica 6.Europe 7.Australia  0.Legv et");

                                        string chooseRegion = Console.ReadLine();

                                        switch (chooseRegion)
                                        {
                                            case "1":
                                                Uopdatedregion = Region.Asia;
                                                break;

                                            case "2":
                                                Uopdatedregion = Region.Africa;
                                                break;
                                            case "3":
                                                Uopdatedregion = Region.NorthAmerica;
                                                break;
                                            case "4":
                                                Uopdatedregion = Region.SouthAmerica;
                                                break;
                                            case "5":
                                                Uopdatedregion = Region.Antarctica;
                                                break;
                                            case "6":
                                                Uopdatedregion = Region.Europe;
                                                break;
                                            case "7":
                                                Uopdatedregion = Region.Australia;
                                                break;
                                            case "0":
                                                isRegionLoop = true;
                                                break;
                                            default:
                                                Console.WriteLine("Bele bir emeliyat yoxdur!");
                                                break;
                                        }
                                        break;
                                    }
                                    while (!isRegionchooseLoop);

                                    AppDbContext.UpdateCountry(planetId, UpadatedcountryName, UpdatedcountryArea, UpdatedcountryAnthem, Uopdatedregion);
                                    break;
                                case "0":
                                    iscountryLoop = true;
                                    break;
                                default:
                                    Console.WriteLine("Bele emeliyyat yoxdur!!");
                                    break;
                            }



                        } while (!iscountryLoop);
                        break;



                    case "0":
                        Console.WriteLine("Sistemden cixis edilir... ");
                        IsMainLoop = true;
                        break;
                    default:
                        Console.WriteLine("Bele emeliyyat movcud deyil!");
                        break;
                }
            }
            while (!IsMainLoop);
        }
    }
}
