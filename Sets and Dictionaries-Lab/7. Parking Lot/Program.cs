namespace _7._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            HashSet<string> set = new HashSet<string>();
            while((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                string carID = tokens[1];
                if(direction == "IN")
                {
                    if(!set.Contains(carID))
                    {
                        set.Add(carID);
                    }

                }else if(direction == "OUT")
                {
                    if (set.Contains(carID))
                    {
                        set.Remove(carID);
                    }
                }
            }
            if(set.Count <= 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            foreach(string car in set)
            {
                Console.WriteLine(car);
            }
        }
    }
}