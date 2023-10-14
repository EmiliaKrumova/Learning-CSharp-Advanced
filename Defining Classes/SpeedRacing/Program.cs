namespace SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < countOfCars; i++)
            {
                string carInfoAsString = Console.ReadLine();
                string[] carInfo = carInfoAsString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelPerKm = double.Parse(carInfo[2]);
                Car car = new Car(model, fuelAmount, fuelPerKm);
                cars.Add(car);

            }
            string command = string.Empty;
            while((command = Console.ReadLine()) != "End")
            {
                //Drive {carModel} {amountOfKm}
                string[] driveInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = driveInfo[1];
                double distance = double.Parse(driveInfo[2]);
                foreach(Car car in cars.FindAll(c=>c.Model==model))
                {
                    car.Drive(distance);
                }
            }
            //"{model} {fuelAmount} {distanceTraveled}"
            foreach(var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }

        }
    }
}