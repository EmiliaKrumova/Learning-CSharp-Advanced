
namespace _6._Wardrobe
{
    internal class Program
    {

//        Create a program that helps you decide what clothes to wear from your wardrobe.You will receive the clothes, which
//are currently in your wardrobe, sorted by their color in the following format:
//"{color} -> {item1},{item2},{item3}…"
//If you receive a certain color, which already exists in your wardrobe, just add the clothes to its records.You can also
//receive repeating items for a certain color and you have to keep their count.
//In the end, you will receive a color and a piece of clothing, which you will look for in the wardrobe, separated by a
//space in the following format:
//"{color} {clothing}"

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string,Dictionary<string,int>> clothes = new Dictionary<string,Dictionary<string,int>>();
            for(int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = line[0];
                string[] clothesinfo = line[1].Split(",",StringSplitOptions.RemoveEmptyEntries);

                for(int j = 0; j < clothesinfo.Length; j++)
                {
                    string currDress = clothesinfo[j];

                    if (!clothes.ContainsKey(color))
                    {
                        clothes[color] = new Dictionary<string, int>();
                    }
                    if (!clothes[color].ContainsKey(currDress))
                    {
                        clothes[color][currDress] = 0;
                    }
                    clothes[color][currDress]++;
                }
                
            }
            string[] looked = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string lookedcolor = looked[0];
            string lookedCloth = looked[1];
            foreach(var kvp in  clothes)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach(var cvp in kvp.Value)
                {
                    if (lookedcolor == kvp.Key && lookedCloth == cvp.Key)
                    {
                        Console.WriteLine($"* {cvp.Key} - {cvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cvp.Key} - {cvp.Value}");
                    }
                   

                }
            }
        }
    }
}