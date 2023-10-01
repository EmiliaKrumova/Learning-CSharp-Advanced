namespace _5._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string,Dictionary<string,List<string>>> countries = new Dictionary<string,Dictionary<string,List<string>>>();
            for(int i = 0; i < count; i++)
            {
                string[] countryData = Console.ReadLine().Split(" ");
                string continent = countryData[0];
                string country = countryData[1];
                string town = countryData[2];
                if (!countries.ContainsKey(continent))
                {
                    countries[continent] = new Dictionary<string, List<string>>();
                    
                }
                if (!countries[continent].ContainsKey(country))
                {
                    countries[continent].Add(country, new List<string>());
                }
                countries[continent][country].Add(town);
            }
            foreach(var continent in countries)
            {
                Console.WriteLine(continent.Key + ":");
                foreach(var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {String.Join(", ",country.Value)}");
                }
            }
        }
    }
}