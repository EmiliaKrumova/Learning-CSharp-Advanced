namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //"Vehicle {initial fuel quantity} {liters per km} {tank capacity}"

            List<IVehicles> list = new List<IVehicles>();
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double quantityCar = double.Parse(carInfo[1]);
            double consumptionCar = double.Parse(carInfo[2]);
            double capacity = double.Parse(carInfo[3]);
            
            IVehicles car = new Car(quantityCar, consumptionCar, capacity);
            list.Add(car);
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double quantityTruck = double.Parse(truckInfo[1]);
            double consumptionTruck = double.Parse(truckInfo[2]);
            double truckCapacity = double.Parse(truckInfo[3]);
            
            IVehicles truck = new Truck(quantityTruck, consumptionTruck, truckCapacity);
            list.Add(truck);


            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double quantityBus = double.Parse(busInfo[1]);
            double consumptionBus = double.Parse(busInfo[2]);
            double BusCapacity = double.Parse(busInfo[3]);
            
            IVehicles bus = new Bus(quantityBus, consumptionBus, BusCapacity);
            list.Add(bus);


            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string realCommand = command[0];
                string typeOfVehicle = command[1];
                IVehicles vehicle = list.FirstOrDefault(v => v.GetType().Name == typeOfVehicle);
                try
                {
                    if (realCommand == "Drive")
                    {
                        bus.IsEmpty = false;
                        double km = double.Parse(command[2]);
                        if (vehicle.CanDrive(km))
                        {
                            vehicle.Drive(km);
                            Console.WriteLine($"{vehicle.GetType().Name} travelled {km} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle.GetType().Name} needs refueling");
                        }

                    }
                    else if (realCommand == "DriveEmpty")
                    {
                        double km = double.Parse(command[2]);
                        bus.IsEmpty = true;
                        if (vehicle.CanDrive(km))
                        {
                            vehicle.Drive(km);
                            Console.WriteLine($"{vehicle.GetType().Name} travelled {km} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle.GetType().Name} needs refueling");
                        }
                    }
                    else if (realCommand == "Refuel")
                    {
                        double liters = double.Parse(command[2]);
                        vehicle.Refuel(liters);


                    }

                }catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message );
                }
               
            }



            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());

            }
        }
    }
}