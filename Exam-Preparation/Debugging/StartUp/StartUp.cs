using Vehicles.Models;
namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var carFuel = double.Parse(carData[1]);
            var carQuantity = double.Parse(carData[2]);
            IVechicle car = new Car(carFuel, carQuantity);

            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var truckFuel = double.Parse(truckData[1]);
            var truckQuantity = double.Parse(truckData[2]);
            IVechicle truck = new Truck(truckFuel, truckQuantity);

            int numberOFCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOFCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeOfAction = cmdArgs[0];
                string typeOfVechicle = cmdArgs[1];
                double distanceOrLiters = double.Parse(cmdArgs[2]);

                if (typeOfVechicle == "Car")
                {
                    if (typeOfAction == "Drive")
                    {
                        car.Driving(distanceOrLiters);
                    }
                    else if (typeOfAction == "Refuel")
                    {
                        car.Refueling(distanceOrLiters);
                    }
                }
                else if (typeOfVechicle == "Truck") 
                {
                    if (typeOfAction == "Drive")
                    {
                        truck.Driving(distanceOrLiters);
                    }
                    else if (typeOfAction == "Refuel") 
                    {
                        truck.Refueling(distanceOrLiters);
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());

        }
    }
}