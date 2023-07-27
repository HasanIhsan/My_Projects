

namespace Exercise6
{
     
    public static class CityStatics
    {
        /*
         * a. A static method called "SortedCities" will return a sorted list of cities.
              The method accepts a list of cities and returns IEnumerable<City>. 
         */
        public static IEnumerable<City> SortedCities(this List<City> cities)
        {
            var sortedCities = from city in cities
                               orderby city.cityName
                               select city;
            return sortedCities;
        }

        /*
         * b. A static method called "CitiesByProvince" will return all cities in each
              province. The method accepts a list of cities and returns
              IEnumerable<IGrouping<string, City>>. 
         */
        public static IEnumerable<IGrouping<string, City>> CitiesByProvince(this List<City> cities)
        {
            var citiesByProvince = from city in cities
                                   group city by city.Province into provinceGroup
                                   select provinceGroup;
            return citiesByProvince;
        }

        /*
         * c. A static method called "ProvincesPopulation" will calculate the total
              population in each province. The method accepts a list of cities and
              returns the "Array" type. It's expected to return an anonymous type
              containing the province name and its total population, as shown in the
              sample output. 
         */
        public static Array ProvincesPopulation(this List<City> cities)
        {
            var provincesPopulation = from city in cities
                                      group city by city.Province into provinceGroup
                                      select new
                                      {
                                          Province = provinceGroup.Key,
                                          Population = provinceGroup.Sum(c => c.Population)
                                      };
            return provincesPopulation.ToArray();
        }
    }
     
}