using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(7, 100);
            vehicle.Drive(10);
            Console.WriteLine(vehicle.Fuel);
            RaceMotorcycle race = new RaceMotorcycle(9,100);
            race.Drive(10);
            Console.WriteLine(race.Fuel);
            Car car = new Car(9,100);
            car.Drive(10);
            Console.WriteLine(car.Fuel);
        }
    }
}
