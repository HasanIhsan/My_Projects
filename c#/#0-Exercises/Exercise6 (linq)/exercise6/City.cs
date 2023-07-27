namespace Exercise6
{
    
    public class City
    {
        public string cityName { get; set; }
        public string Province { get; set; }
        public int Population { get; set; }

        public City(string name, string provice, int population) 
        {
            cityName = name;
            Province = provice;
            Population = population;
        }

        public override string ToString()
        {
            return cityName;
        }
    }
     
}