using CsQuery.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Dynamic;

namespace Project1
{
    
    using Dictionary_T = Dictionary<string, List<CityInfo>>;

    public class Statistics
    {
        public Dictionary_T CityCatelogue { get; init; }

        const string DIR_EXT = "../../../data/";

        public Statistics(string fileName, string fileType)
        {
            DataModeler dm = new DataModeler();
            CityCatelogue = dm.ParseFile(fileName, fileType);
        }

        //City Methods
        public List<CityInfo>? DisplayCityInformation(string cityName)
        {
            if (!CityCatelogue.ContainsKey(cityName))
                throw new ArgumentOutOfRangeException(nameof(cityName), $"{cityName} is not a city from the collection.");
            return CityCatelogue[cityName];
        }

        public CityInfo? DisplayLargestPopulationCity(string province)
        {
            return SortCities(new OrderByPopulation(), CityCatelogue).Last(city => city.Province == province);
        }

        public CityInfo? DisplaySmallestPopulationCity(string province)
        {
            return SortCities(new OrderByPopulation(), CityCatelogue).First(city => city.Province == province);
        }

        public CityInfo? CompareCitiesPopulation(CityInfo city1, CityInfo city2)
        {
            return city1.Population > city2.Population ? city1 : city2;
        }

        public void ShowCityOnMap(string cityName, string prov)
        {
            CityInfo? city = GetCity(cityName, prov);

            if (city == null)
                throw new ArgumentOutOfRangeException(nameof(city), $"Province doesn't have a city named {cityName}");

            Process.Start(new ProcessStartInfo(($"https://www.latlong.net/c/?lat={city.Lat}&long={city.Lng}")) { UseShellExecute = true });
        }

        public int? CalculateDistanceBetweenCities(CityInfo city1, CityInfo city2)
        {
            string key = "AIzaSyBuWX6ELFtlNhqHk5EcKrmXWBdrmHeNm5A";
            string url = $"https://maps.googleapis.com/maps/api/distancematrix/json?destinations={city2.CityName.Replace(" ", "%20")}%2C{city2.Province}&origins={city1.CityName.Replace(" ", "%20")}%2C{city1.Province}&key={key}";
            int? distance = null;
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(url).Result;

                string responseBody = response.Content.ReadAsStringAsync().Result;
                JToken? token = JObject.Parse(responseBody).SelectToken(".rows[0].elements[0].distance.value");
                if (token != null)
                    distance = token.Value<int?>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return distance;
        }

        public int? CalculateDistanceToCapital(CityInfo city)
        {
            return CalculateDistanceBetweenCities(city, GetCapital(city.Province)!);
        }

        //Province Methods
        public int DisplayProvincePopulation(string province)
        {
            return DisplayProvinceCities(province).Sum(city => city.Population);
        }

        public List<CityInfo> DisplayProvinceCities(string province)
        {
            return CityCatelogue.SelectMany(kvp => kvp.Value.Where(city => city.Province == province)).ToList();
        }

        public Dictionary<string, int> RankProvinceByPopulation()
        {
            List<string> provinceList = GetProvinceList();
            Dictionary_T provAndPop = new Dictionary_T();
            foreach (string prov in provinceList)
            {
                int id = 0;
                provAndPop.Add(prov, new List<CityInfo>());
                provAndPop[prov].Add(new CityInfo(id++, prov, prov, DisplayProvincePopulation(prov), prov, 0.0, 0.0, ""));
            }

            return SortCities(new OrderByPopulation(), provAndPop).ToDictionary(x => x.CityName, y => y.Population);
        }

        public Dictionary<string, int> RankProvincesByCities()
        {
            List<string> provinceList = GetProvinceList();
            Dictionary_T provAndPop = new Dictionary_T();
            foreach(string prov in provinceList)
            {
                int id = 0;
                provAndPop.Add(prov, new());
                provAndPop[prov].Add(new CityInfo(id++, prov, prov, DisplayProvinceCities(prov).Count(), prov, 0.0, 0.0, ""));
            }

            return SortCities(new OrderByPopulation(), provAndPop).ToDictionary(city => city.Province, city => city.Population);
        }

        public CityInfo? GetCapital(string province)
        {
            return DisplayProvinceCities(province).Find(city => city.Capital == "provincial");
        }

        public static void OnCityPopulationChange(CityPopulationChangeEvent changeData, Dictionary_T catelogue, string fileName, string fileType)
        {
            DataModeler model = new DataModeler();
            GUI.GUI.printError($"City population for {changeData.CurrentCity.CityName}, {changeData.CurrentCity.Province} has changed from {changeData.CurrentCity.Population} to {changeData.NewPop}");
            catelogue[changeData.CurrentCity.CityName].Find(city => city.Province == changeData.CurrentCity.Province)!.Population = changeData.NewPop;
            model.Deserialize($"{DIR_EXT}{fileName}", fileType, catelogue);
            //Alert client with changeData
        }
        
        //Private helper methods
        private SortedSet<CityInfo> SortCities(IComparer<CityInfo> sorter, Dictionary_T list)
        {
            SortedSet<CityInfo> ss = new SortedSet<CityInfo>(sorter);

            CityCatelogue.ForEach(kvp => kvp.Value.ForEach(city => ss.Add(city)));

            return ss;
        }

        public CityInfo? GetCity(string cityName, string province)
        {
            if (!CityCatelogue.ContainsKey(cityName))
                throw new ArgumentOutOfRangeException(cityName, $"City {cityName} not found in catelogue.");

            CityInfo? city = CityCatelogue[cityName].Find(c => c.Province == province);
            
            return city;
        }

        private List<string> GetProvinceList()
        {
            IEnumerable<string> provinceQuery = from kvp in CityCatelogue from city in kvp.Value select city.Province;
            return provinceQuery.Distinct().ToList();
        }
    }
}