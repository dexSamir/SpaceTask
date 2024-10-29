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
            int planetId;


            string countryName;
            string countryAnthem; 
            Region region = new Region();
            double countryArea;

            int COuntryId; 
            do
            {
                Console.Clear(); 
                Console.WriteLine("1. Planet Menu \n2. Country Menu \n0. EXIT\n");
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
                                    isFalse = AppDbContext.checkPlanet(planetId);
                                    if (isFalse)
                                    {

                                        string? UpdateplanetName = null;
                                        double? UpdatePlanetArea = null;

                                        Console.WriteLine("Planetin adini deyismek isteyirsiniz mi? (he/yox) ");
                                        string answer = Console.ReadLine();
                                        if(answer.ToLower().Trim() == "he")
                                        {
                                            Console.WriteLine("Planetin yeni adini daxil edin: ");
                                            UpdateplanetName = Console.ReadLine();
                                        }

                                        Console.WriteLine("Planetin sahesini deyismek isteyirsiniz mi? (he/yox)");
                                        answer = Console.ReadLine(); 
                                        if(answer.Trim().ToLower() == "he")
                                        {

                                            Console.WriteLine("Planetin yeni sahesini daxil edin: ");
                                            double tempArea; 
                                            isFalse = double.TryParse(Console.ReadLine(), out tempArea);

                                            UpdatePlanetArea = tempArea; 

                                            while (!isFalse)
                                            {
                                                
                                                Console.WriteLine("Planetin sahesini duzdun daxil edin!!!");
                                                isFalse = double.TryParse(Console.ReadLine(), out tempArea);
                                                UpdatePlanetArea = tempArea; 
                                            }

                                        } 

                                        AppDbContext.UpdatePlanet(planetId, UpdateplanetName, UpdatePlanetArea);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Verilen Id-ye uygun planet tapilmadi!\n");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Bele emeliyyat yoxdur!!\n");
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
                                    Console.WriteLine($"{country.CountryName} adli olke yaradildi\n");

                                    break; 
                                case "2":
                                    AppDbContext.GetAllCountries(); 
                                    break;
                                case "3":
                                    Console.WriteLine("Country Id-sini daxil edin: ");
                                    isFalse = int.TryParse(Console.ReadLine(), out COuntryId);

                                    string? UpadatedcountryName = null;
                                    string UpdatedcountryAnthem = null;
                                    Region? Uopdatedregion = null;
                                    double? UpdatedcountryArea =  null;


                                    while (!isFalse)
                                    {
                                        Console.WriteLine("Country id-ni duzgun daxil edin!!!");
                                        isFalse = int.TryParse(Console.ReadLine(), out COuntryId);
                                    }
                                    isFalse = AppDbContext.checkCountry(COuntryId);
                                    if (isFalse)
                                    {
                                        Console.WriteLine("Olkenin adini deyismek isteyirsiniz mi? (he/yox)");
                                        string answer = Console.ReadLine();
                                        
                                        if(answer.Trim().ToLower() == "he")
                                        {
                                            Console.WriteLine("Country yeni adini daxil edin: ");
                                            UpadatedcountryName = Console.ReadLine();
                                        }

                                        Console.WriteLine("Olkenin Sahesini deyismek isteyirsiniz mi? (he/yox)");
                                        answer = Console.ReadLine(); 
                                        if(answer.Trim().ToLower() == "he")
                                        {
                                            double tempArea; 
                                            Console.WriteLine("Planetin yeni sahesini daxil edin: ");
                                            isFalse = double.TryParse(Console.ReadLine(), out tempArea);
                                            UpdatedcountryArea = tempArea; 

                                            while (!isFalse)
                                            {
                                                Console.WriteLine("Planetin sahesini duzdun daxil edin!!!");
                                                isFalse = double.TryParse(Console.ReadLine(), out tempArea);
                                                UpdatedcountryArea = tempArea;

                                            }
                                        }
                                        

                                        Console.WriteLine("Olkenin himnini deyismek isteyirsiniz mi? (he/yox)");
                                        answer = Console.ReadLine();

                                        if (answer.Trim().ToLower() == "he")
                                        {
                                            Console.WriteLine("Country yeni himnini daxil edin: ");
                                            UpdatedcountryAnthem = Console.ReadLine();
                                        }
                                        Console.WriteLine("Olkenin regionunu deyismek isteyirsiniz mi? (he/yox)");
                                        answer = Console.ReadLine();
                                        if(answer.ToLower().Trim() == "he")
                                        {

                                            bool isRegionchooseLoop;
                                            Console.WriteLine("Olkenin yeni regionunu secin: ");
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

                                        }
                                        AppDbContext.UpdateCountry(COuntryId, UpadatedcountryName, UpdatedcountryArea, UpdatedcountryAnthem, Uopdatedregion);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Verilen Id-ye uygun olke tapilmadi!\n");
                                    }

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
