namespace _8._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                char firstSymbol = input[0];
                if (char.IsDigit(firstSymbol))
                {
                    if (!vip.Contains(input))
                    {
                        vip.Add(input);
                    }
                }
                else
                {
                    if (!regular.Contains(input))
                    {
                        regular.Add(input);
                    }
                } 
            }
            if (input == "PARTY")
            {
                while ((input = Console.ReadLine()) != "END")
                {
                    char firstSymbol = input[0];
                    if (char.IsDigit(firstSymbol))
                    {
                        if (vip.Contains(input))
                        {
                            vip.Remove(input);
                        }
                    }
                    else
                    {
                        if (regular.Contains(input))
                        {
                            regular.Remove(input);
                        }
                    }
                }
            }            

            
            Console.WriteLine(vip.Count+regular.Count);
            foreach(var guest in vip)
            {
                Console.WriteLine(guest);
            }
            foreach(var guest in regular)
            {
                Console.WriteLine(guest);
            }



        }
    }
}