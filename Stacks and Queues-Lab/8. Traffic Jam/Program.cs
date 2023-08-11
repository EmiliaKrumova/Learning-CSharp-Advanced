namespace _8._Traffic_Jam
{

    /*Create a program that simulates the queue that forms during a traffic jam. During a traffic jam only N cars can pass the crossroads when the light goes green. Then the program reads the vehicles that arrive one by one and adds them to the queue. When the light goes green N number of cars pass the crossroads and for each a message "{car} passed!" is displayed. When the "end" command is given, terminate the program and display a message with the total number of cars that passed the crossroads.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
           int carsToPassAtGreenLight = int.Parse(Console.ReadLine());
            string command;
            int carsPassed = 0;
            Queue<string> cars = new Queue<string>();
            while((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0;i< carsToPassAtGreenLight; i++)
                    {
                        if(cars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carsPassed++;
                    }
                   

                }
                else
                {
                    cars.Enqueue(command);
                }

            }
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}