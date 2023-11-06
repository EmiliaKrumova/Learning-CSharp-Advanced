namespace Telephony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StationaryPhone stationary = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            string[] phonenumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < phonenumbers.Length; i++)
            {
                string currNumber = phonenumbers[i];
                if (currNumber.Length == 7)
                {
                    Console.WriteLine(stationary.Calling(currNumber));
                }
                else if (currNumber.Length == 10)
                {
                    Console.WriteLine(smartphone.Calling(currNumber));

                }
            }
            string[] urls = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < urls.Length; i++)
            {
                string curentURL = urls[i];
                Console.WriteLine(smartphone.Browse(curentURL));
            }
        
        }
    }
}