namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> list = new List<Vehicle>();
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double quantityCar = double.Parse(carInfo[1]);
            double consumptionCar = double.Parse(carInfo[2]);
            Car car = new Car(quantityCar,consumptionCar);
            list.Add(car);
            string[] truckInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            double quantityTruck = double.Parse(truckInfo[1]);
            double consumptionTruck = double.Parse(truckInfo[2]);
            Truck truck = new Truck(quantityTruck,consumptionTruck);
            list.Add(truck);

            int counter = int.Parse(Console.ReadLine());
            for(int i = 0; i < counter; i++)
            {
                string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string realCommand = command[0];
                string typeOfVehicle = command[1];
                Vehicle vehicle = list.FirstOrDefault(v => v.GetType().Name == typeOfVehicle);
                if (realCommand == "Drive")
                {
                    
                    double km = double.Parse(command[2]);
                    
                    if(vehicle != null)
                    {
                        Console.WriteLine(vehicle.Drive(km));
                    }
                    
                }
                else if(realCommand == "Refuel")
                {
                    double liters = double.Parse(command[2]);
                    if (vehicle != null)
                    {
                        vehicle.Refuel(liters);
                    }


                }
            }
            foreach(var vehicle in list)
            {
                Console.WriteLine(vehicle.ToString());

            }

        }
    }
}